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
    public class FullTourInfoService
    {
        IRepository<FullTourInfo> fullTourInfoRepository;
        IMapper mapper;
        public FullTourInfoService(IRepository<FullTourInfo> repository)
        {
            fullTourInfoRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<FullTourInfo, FullTourInfoDTO>();
                x.CreateMap<FullTourInfoDTO, FullTourInfo>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<FullTourInfoDTO> GetAll()
        {
            return mapper.Map<IEnumerable<FullTourInfo>, IEnumerable<FullTourInfoDTO>>(fullTourInfoRepository.GetAll());
        }

        public FullTourInfoDTO Get(int fullTourInfoId)
        {
            FullTourInfo fullTourInfo = fullTourInfoRepository.GetByOneIndex(fullTourInfoId);
            return mapper.Map<FullTourInfo, FullTourInfoDTO>(fullTourInfo);
        }

        // View is only a shortcut to the select query
        // you can't update information in select query it is not an eternal table
    }
}
