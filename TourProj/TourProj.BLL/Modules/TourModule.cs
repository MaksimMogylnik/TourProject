using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProj.BLL.DTO;
using TourProj.BLL.Services;
using TourProj.DAL.Context;
using TourProj.DAL.Repositories;

namespace TourProj.BLL.Modules
{
    public class TourModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<TourDBEntities>();

            Bind<IRepository<Archive>>().To<GenericRepository<Archive>>();
            Bind<ArchiveService>().To<ArchiveService>();

            Bind<IRepository<City>>().To<GenericRepository<City>>();
            Bind<CityService>().To<CityService>();

            Bind<IRepository<Client>>().To<GenericRepository<Client>>();
            Bind<ClientService>().To<ClientService>();

            Bind<IRepository<Country>>().To<GenericRepository<Country>>();
            Bind<CountryService>().To<CountryService>();

            Bind<IRepository<FullTourInfo>>().To<GenericRepository<FullTourInfo>>();
            Bind<FullTourInfoService>().To<FullTourInfoService>();

            Bind<IRepository<Hotel>>().To<GenericRepository<Hotel>>();
            Bind<HotelService>().To<HotelService>();

            Bind<IRepository<PayedTour>>().To<GenericRepository<PayedTour>>();
            Bind<PayedTourService>().To<PayedTourService>();

            Bind<IRepository<Post>>().To<GenericRepository<Post>>();
            Bind<PostService>().To<PostService>();

            Bind<IRepository<Sight>>().To<GenericRepository<Sight>>();
            Bind<SightService>().To<SightService>();

            Bind<IRepository<Tour>>().To<GenericRepository<Tour>>();
            Bind<TourService>().To<TourService>();

            Bind<IRepository<TourVisit>>().To<GenericRepository<TourVisit>>();
            Bind<TourVisitService>().To<TourVisitService>();

            Bind<IRepository<Transport>>().To<GenericRepository<Transport>>();
            Bind<TransportService>().To<TransportService>();

            Bind<IRepository<Worker>>().To<GenericRepository<Worker>>();
            Bind<WorkerService>().To<WorkerService>();
        }
    }
}
