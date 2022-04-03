using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProj.BLL.DTO;
using TourProj.DAL.Context;
using TourProj.DAL.Repositories;

namespace TourProj.BLL.Services
{
    public class ClientService
    {
        IRepository<Client> clientRepository;
        IMapper mapper;
        public ClientService(IRepository<Client> repository)
        {
            clientRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Client, ClientDTO>()
                    .ForMember(y => y.ClientID, y => y.MapFrom(prop => prop.ClientID))
                    .ForMember(y => y.ClientFullName, y => y.MapFrom(prop => prop.ClientFullName))
                    .ForMember(y => y.Phone, y => y.MapFrom(prop => prop.Phone))
                    .ForMember(y => y.Email, y => y.MapFrom(prop => prop.Email))
                    .ForMember(y => y.BirthDate, y => y.MapFrom(prop => prop.BirthDate));
                x.CreateMap<ClientDTO, Client>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(clientRepository.GetAll());
        }

        public ClientDTO Get(int clientId)
        {
            Client client = clientRepository.GetByOneIndex(clientId);
            return mapper.Map<Client, ClientDTO>(client);
        }

        public ClientDTO Delete(ClientDTO clientDTO)
        {
            Client clientToRemove = clientRepository.GetByOneIndex(clientDTO.ClientID);
            clientRepository.Delete(clientToRemove);
            clientRepository.SaveChanges();
            return clientDTO;
        }

        public void CreateOrUpdate(ClientDTO clientDTO)
        {
            Client clientTour = mapper.Map<ClientDTO, Client>(clientDTO);
            clientRepository.CreateOrUpdate(clientTour);
            clientRepository.SaveChanges();
        }
    }
}
