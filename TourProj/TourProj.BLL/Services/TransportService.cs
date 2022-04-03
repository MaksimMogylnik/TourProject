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
    public class TransportService
    {
        IRepository<Transport> transportRepository;
        IMapper mapper;
        public TransportService(IRepository<Transport> repository)
        {
            transportRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Transport, TransportDTO>()
                    .ForMember(y => y.TransportID, y => y.MapFrom(prop => prop.TransportID))
                    .ForMember(y => y.TransportType, y => y.MapFrom(prop => prop.TransportType));
                x.CreateMap<TransportDTO, Transport>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<TransportDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Transport>, IEnumerable<TransportDTO>>(transportRepository.GetAll());
        }

        public TransportDTO Get(int transportId)
        {
            Transport transport = transportRepository.GetByOneIndex(transportId);
            return mapper.Map<Transport, TransportDTO>(transport);
        }

        public TransportDTO Delete(TransportDTO transportDTO)
        {
            Transport transportToRemove = transportRepository.GetByOneIndex(transportDTO.TransportID);
            transportRepository.Delete(transportToRemove);
            transportRepository.SaveChanges();
            return transportDTO;
        }

        public void CreateOrUpdate(TransportDTO transportDTO)
        {
            Transport transportTour = mapper.Map<TransportDTO, Transport>(transportDTO);
            transportRepository.CreateOrUpdate(transportTour);
            transportRepository.SaveChanges();
        }
    }
}
