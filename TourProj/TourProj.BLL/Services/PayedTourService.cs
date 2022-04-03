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
    public class PayedTourService
    {
        IRepository<PayedTour> payedTourRepository;
        IMapper mapper;
        public PayedTourService(IRepository<PayedTour> repository)
        {
            payedTourRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<PayedTour, PayedTourDTO>()
                    .ForMember(y => y.TourID, y => y.MapFrom(prop => prop.TourID))
                    .ForMember(y => y.ClientID, y => y.MapFrom(prop => prop.ClientID))
                    .ForMember(y => y.Payment, y => y.MapFrom(prop => prop.Payment));
                x.CreateMap<PayedTourDTO, PayedTour>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<PayedTourDTO> GetAll()
        {
            return mapper.Map<IEnumerable<PayedTour>, IEnumerable<PayedTourDTO>>(payedTourRepository.GetAll());
        }

        public PayedTourDTO Get(int tourId, int clientId)
        {
            PayedTour payedTour = payedTourRepository.GetByTwoIndexes(tourId, clientId);
            return mapper.Map<PayedTour, PayedTourDTO>(payedTour);
        }

        public PayedTourDTO Delete(PayedTourDTO payedTourDTO)
        {
            PayedTour payedTourToRemove = payedTourRepository.GetByTwoIndexes(payedTourDTO.TourID, payedTourDTO.ClientID);
            payedTourRepository.Delete(payedTourToRemove);
            payedTourRepository.SaveChanges();
            return payedTourDTO;
        }

        public void CreateOrUpdate(PayedTourDTO payedTourDTO)
        {
            PayedTour payedTour = mapper.Map<PayedTourDTO, PayedTour>(payedTourDTO);
            payedTourRepository.CreateOrUpdate(payedTour);
            payedTourRepository.SaveChanges();
        }
    }
}
