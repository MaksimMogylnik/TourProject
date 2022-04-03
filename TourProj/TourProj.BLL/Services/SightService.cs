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
    public class SightService
    {
        IRepository<Sight> sightRepository;
        IMapper mapper;
        public SightService(IRepository<Sight> repository)
        {
            sightRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Sight, SightDTO>()
                    .ForMember(y => y.SightID, y => y.MapFrom(prop => prop.SightID))
                    .ForMember(y => y.SightName, y => y.MapFrom(prop => prop.SightName))
                    .ForMember(y => y.CoutryID, y => y.MapFrom(prop => prop.CoutryID))
                    .ForMember(y => y.CityID, y => y.MapFrom(prop => prop.CityID))
                    .ForMember(y => y.ImageUri, y => y.MapFrom(prop => prop.ImageUri));
                x.CreateMap<SightDTO, Sight>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<SightDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Sight>, IEnumerable<SightDTO>>(sightRepository.GetAll());
        }

        public SightDTO Get(int sightId)
        {
            Sight sight = sightRepository.GetByOneIndex(sightId);
            return mapper.Map<Sight, SightDTO>(sight);
        }

        public SightDTO Delete(SightDTO sightDTO)
        {
            Sight sightToRemove = sightRepository.GetByOneIndex(sightDTO.SightID);
            sightRepository.Delete(sightToRemove);
            sightRepository.SaveChanges();
            return sightDTO;
        }

        public void CreateOrUpdate(SightDTO sightDTO)
        {
            Sight sightTour = mapper.Map<SightDTO, Sight>(sightDTO);
            sightRepository.CreateOrUpdate(sightTour);
            sightRepository.SaveChanges();
        }
    }
}
