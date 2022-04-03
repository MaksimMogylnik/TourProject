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
    public class TourService
    {
        IRepository<Tour> tourRepository;
        IMapper mapper;
        public TourService(IRepository<Tour> repository)
        {
            tourRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Tour, TourDTO>()
                    .ForMember(y => y.TourID, y => y.MapFrom(prop => prop.TourID))
                    .ForMember(y => y.TourName, y => y.MapFrom(prop => prop.TourName))
                    .ForMember(y => y.Cost, y => y.MapFrom(prop => prop.Cost))
                    .ForMember(y => y.StartDate, y => y.MapFrom(prop => prop.StartDate))
                    .ForMember(y => y.FinishDate, y => y.MapFrom(prop => prop.FinishDate))
                    .ForMember(y => y.MaxPeople, y => y.MapFrom(prop => prop.MaxPeople))
                    .ForMember(y => y.TransportID, y => y.MapFrom(prop => prop.TransportID))
                    .ForMember(y => y.IsDeleted, y => y.MapFrom(prop => prop.IsDeleted));
                x.CreateMap<TourDTO, Tour>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<TourDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Tour>, IEnumerable<TourDTO>>(tourRepository.GetAll());
        }

        public TourDTO Get(int tourId)
        {
            Tour tour = tourRepository.GetByOneIndex(tourId);
            return mapper.Map<Tour, TourDTO>(tour);
        }

        public TourDTO Delete(TourDTO tourDTO)
        {
            Tour tourToRemove = tourRepository.GetByOneIndex(tourDTO.TourID);
            tourRepository.Delete(tourToRemove);
            tourRepository.SaveChanges();
            return tourDTO;
        }

        public void CreateOrUpdate(TourDTO tourDTO)
        {
            Tour tourTour = mapper.Map<TourDTO, Tour>(tourDTO);
            tourRepository.CreateOrUpdate(tourTour);
            tourRepository.SaveChanges();
        }
    }
}
