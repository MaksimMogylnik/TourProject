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
    public class CountryService
    {
        IRepository<Country> countryRepository;
        IMapper mapper;
        public CountryService(IRepository<Country> repository)
        {
            countryRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Country, CountryDTO>()
                    .ForMember(y => y.CoutryID, y => y.MapFrom(prop => prop.CoutryID))
                    .ForMember(y => y.CoutryName, y => y.MapFrom(prop => prop.CoutryName));
                x.CreateMap<CountryDTO, Country>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<CountryDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Country>, IEnumerable<CountryDTO>>(countryRepository.GetAll());
        }

        public CountryDTO Get(int countryId)
        {
            Country country = countryRepository.GetByOneIndex(countryId);
            return mapper.Map<Country, CountryDTO>(country);
        }

        public CountryDTO Delete(CountryDTO countryDTO)
        {
            Country countryToRemove = countryRepository.GetByOneIndex(countryDTO.CoutryID);
            countryRepository.Delete(countryToRemove);
            countryRepository.SaveChanges();
            return countryDTO;
        }

        public void CreateOrUpdate(CountryDTO countryDTO)
        {
            Country countryTour = mapper.Map<CountryDTO, Country>(countryDTO);
            countryRepository.CreateOrUpdate(countryTour);
            countryRepository.SaveChanges();
        }
    }
}
