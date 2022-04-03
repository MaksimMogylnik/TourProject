using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProj.DAL.Context;

namespace TourProj.DAL.Repositories
{
    public sealed class TourContextRepositoryFactory
    {
        private TourDBEntities context = new TourDBEntities();

        public IRepository<FullTourInfo> GetFullTourInfoRepository()
            => new GenericRepository<FullTourInfo>(context);

        public IRepository<Worker> GetWorkerRepository()
            => new GenericRepository<Worker>(context);

        public IRepository<Archive> GetArchiveREpository()
            => new GenericRepository<Archive>(context);

        public IRepository<City> GetCityRepository()
            => new GenericRepository<City>(context);

        public IRepository<Client> GetRepository()
            => new GenericRepository<Client>(context);

        public IRepository<Country> GetCountryRepository()
            => new GenericRepository<Country>(context);

        public IRepository<Hotel> GetHotelRepository()
            => new GenericRepository<Hotel>(context);

        public IRepository<PayedTour> GetPayedTourRepository()
            => new GenericRepository<PayedTour>(context);

        public IRepository<Post> GetPostRepository()
            => new GenericRepository<Post>(context);

        public IRepository<Sight> GetSightRepository()
            => new GenericRepository<Sight>(context);

        public IRepository<Tour> GetTourRepository()
            => new GenericRepository<Tour>(context);

        public IRepository<TourVisit> GetTourVisitRepository()
            => new GenericRepository<TourVisit>(context);

        public IRepository<Transport> GetTransportRepository()
            => new GenericRepository<Transport>(context);
    }
}
