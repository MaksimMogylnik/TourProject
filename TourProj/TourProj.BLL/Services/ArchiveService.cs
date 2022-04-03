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
    public class ArchiveService
    {
        IRepository<Archive> archiveRepository;
        IMapper mapper;
        public ArchiveService(IRepository<Archive> repository)
        {
            archiveRepository = repository;
            MapperConfiguration config = new MapperConfiguration(x =>
            {
                x.CreateMap<Archive, ArchiveDTO>()
                    .ForMember(y => y.TourID, y => y.MapFrom(prop => prop.TourID))
                    .ForMember(y => y.ClientID, y => y.MapFrom(prop => prop.ClientID))
                    .ForMember(y => y.Payment, y => y.MapFrom(prop => prop.Payment));
                x.CreateMap<ArchiveDTO, Archive>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<ArchiveDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Archive>, IEnumerable<ArchiveDTO>>(archiveRepository.GetAll());
        }

        public ArchiveDTO Get(int tourId, int clientId)
        {
            Archive archiveTour = archiveRepository.GetByTwoIndexes(tourId, clientId);
            return mapper.Map<Archive, ArchiveDTO>(archiveTour);
        }

        public ArchiveDTO Delete(ArchiveDTO archiveDTO)
        {
            Archive archiveTourToRemove = archiveRepository.GetByTwoIndexes(archiveDTO.TourID, archiveDTO.ClientID);
            archiveRepository.Delete(archiveTourToRemove);
            archiveRepository.SaveChanges();
            return archiveDTO;
        }

        public void CreateOrUpdate(ArchiveDTO archiveDTO)
        {
            Archive archiveTour = mapper.Map<ArchiveDTO, Archive>(archiveDTO);
            archiveRepository.CreateOrUpdate(archiveTour);
            archiveRepository.SaveChanges();
        }
    }
}
