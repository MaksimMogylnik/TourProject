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
    public class TourVisitService
    {
        IRepository<TourVisit> tourVisitRepository;
        IMapper mapper;
        public TourVisitService(IRepository<TourVisit> repository)
        {
            tourVisitRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<TourVisit, TourVisitDTO>()
                    .ForMember(y => y.TourID, y => y.MapFrom(prop => prop.TourID))
                    .ForMember(y => y.CoutryID, y => y.MapFrom(prop => prop.CoutryID))
                    .ForMember(y => y.CityID, y => y.MapFrom(prop => prop.CityID))
                    .ForMember(y => y.TourID, y => y.MapFrom(prop => prop.TourID))
                    .ForMember(y => y.VisitDate, y => y.MapFrom(prop => prop.VisitDate));
                x.CreateMap<TourVisitDTO, TourVisit>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<TourVisitDTO> GetAll()
        {
            return mapper.Map<IEnumerable<TourVisit>, IEnumerable<TourVisitDTO>>(tourVisitRepository.GetAll());
        }

        public TourVisitDTO Get(int tourId, int cityId)
        {
            TourVisit tourVisit = tourVisitRepository.GetByTwoIndexes(tourId, cityId);
            return mapper.Map<TourVisit, TourVisitDTO>(tourVisit);
        }

        public TourVisitDTO Delete(TourVisitDTO tourVisitDTO)
        {
            TourVisit tourVisitToRemove = tourVisitRepository.GetByTwoIndexes(tourVisitDTO.TourID, tourVisitDTO.CityID);
            tourVisitRepository.Delete(tourVisitToRemove);
            tourVisitRepository.SaveChanges();
            return tourVisitDTO;
        }

        public void CreateOrUpdate(TourVisitDTO tourVisitDTO)
        {
            TourVisit tourVisit = mapper.Map<TourVisitDTO, TourVisit>(tourVisitDTO);
            tourVisitRepository.CreateOrUpdate(tourVisit);
            tourVisitRepository.SaveChanges();
        }
    }
}
