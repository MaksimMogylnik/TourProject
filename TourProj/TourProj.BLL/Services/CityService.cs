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
    public class CityService
    {
        IRepository<City> cityRepository;
        IMapper mapper;
        public CityService(IRepository<City> repository)
        {
            cityRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<City, CityDTO>()
                    .ForMember(y => y.CityID, y => y.MapFrom(prop => prop.CityID))
                    .ForMember(y => y.CityName, y => y.MapFrom(prop => prop.CityName));
                x.CreateMap<CityDTO, City>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<CityDTO> GetAll()
        {
            return mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(cityRepository.GetAll());
        }

        public CityDTO Get(int cityId)
        {
            City city = cityRepository.GetByOneIndex(cityId);
            return mapper.Map<City, CityDTO>(city);
        }

        public CityDTO Delete(CityDTO cityDTO)
        {
            City cityToRemove = cityRepository.GetByOneIndex(cityDTO.CityID);
            cityRepository.Delete(cityToRemove);
            cityRepository.SaveChanges();
            return cityDTO;
        }

        public void CreateOrUpdate(CityDTO cityDTO)
        {
            City cityTour = mapper.Map<CityDTO, City>(cityDTO);
            cityRepository.CreateOrUpdate(cityTour);
            cityRepository.SaveChanges();
        }
    }
}
