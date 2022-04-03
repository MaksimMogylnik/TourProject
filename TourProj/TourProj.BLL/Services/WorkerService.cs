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
    public class WorkerService
    {
        IRepository<Worker> workerRepository;
        IMapper mapper;
        public WorkerService(IRepository<Worker> repository)
        {
            workerRepository = repository;
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

                x.CreateMap<Worker, WorkerDTO>()
                    .ForMember(y => y.WorkerID, y => y.MapFrom(prop => prop.WorkerID))
                    .ForMember(y => y.FullName, y => y.MapFrom(prop => prop.FullName))
                    .ForMember(y => y.PostID, y => y.MapFrom(prop => prop.PostID))
                    .ForMember(y => y.Phone, y => y.MapFrom(prop => prop.Phone))
                    .ForMember(y => y.Email, y => y.MapFrom(prop => prop.Email))
                    .ForMember(y => y.AcceptDate, y => y.MapFrom(prop => prop.AcceptDate))
                    .ForMember(y => y.IsFired, y => y.MapFrom(prop => prop.IsFired))
                    .ForMember(y => y.Tours, y => y.MapFrom(prop => prop.Tours));
                x.CreateMap<WorkerDTO, Worker>();
            });

            mapper = new Mapper(config);
        }

        public IEnumerable<WorkerDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Worker>, IEnumerable<WorkerDTO>>(workerRepository.GetAll());
        }

        public WorkerDTO Get(int workerId)
        {
            Worker worker = workerRepository.GetByOneIndex(workerId);
            return mapper.Map<Worker, WorkerDTO>(worker);
        }

        public WorkerDTO Delete(WorkerDTO workerDTO)
        {
            Worker workerToRemove = workerRepository.GetByOneIndex(workerDTO.WorkerID);
            workerRepository.Delete(workerToRemove);
            workerRepository.SaveChanges();
            return workerDTO;
        }

        public void CreateOrUpdate(WorkerDTO workerDTO)
        {
            Worker workerTour = mapper.Map<WorkerDTO, Worker>(workerDTO);
            workerRepository.CreateOrUpdate(workerTour);
            workerRepository.SaveChanges();
        }
    }
}
