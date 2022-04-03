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
    public class HotelService
    {
        IRepository<Hotel> hotelRepository;
        IMapper mapper;
        public HotelService(IRepository<Hotel> repository)
        {
            hotelRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Hotel, HotelDTO>()
                    .ForMember(y => y.HotelID, y => y.MapFrom(prop => prop.HotelID))
                    .ForMember(y => y.HotelName, y => y.MapFrom(prop => prop.HotelName))
                    .ForMember(y => y.ImageUri, y => y.MapFrom(prop => prop.ImageUri));
                x.CreateMap<HotelDTO, Hotel>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<HotelDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Hotel>, IEnumerable<HotelDTO>>(hotelRepository.GetAll());
        }

        public HotelDTO Get(int hotelId)
        {
            Hotel hotel = hotelRepository.GetByOneIndex(hotelId);
            return mapper.Map<Hotel, HotelDTO>(hotel);
        }

        public HotelDTO Delete(HotelDTO hotelDTO)
        {
            Hotel hotelToRemove = hotelRepository.GetByOneIndex(hotelDTO.HotelID);
            hotelRepository.Delete(hotelToRemove);
            hotelRepository.SaveChanges();
            return hotelDTO;
        }

        public void CreateOrUpdate(HotelDTO hotelDTO)
        {
            Hotel hotelTour = mapper.Map<HotelDTO, Hotel>(hotelDTO);
            hotelRepository.CreateOrUpdate(hotelTour);
            hotelRepository.SaveChanges();
        }
    }
}
