using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProj.BLL.Modules;
using TourProj.UI.ViewModels;

namespace TourProj.UI.Infrastructure
{
    class ViewModelsLocator
    {
        IKernel kernel;
        public ViewModelsLocator()
        {
            kernel = new StandardKernel(new TourModule());
        }

        public ArchiveTourTableViewModel AcrhiveTourTableViewModel => kernel.Get<ArchiveTourTableViewModel>();

        public AdminTourTableViewModel AdminTourTableViewModel => kernel.Get<AdminTourTableViewModel>();

        public CityTableViewModel CityTableViewModel => kernel.Get<CityTableViewModel>();

        public ClientTableViewModel ClientTableViewModel => kernel.Get<ClientTableViewModel>();

        public CountryTableViewModel CountryTableViewModel => kernel.Get<CountryTableViewModel>();

        public HotelTableViewModel HotelTableViewModel => kernel.Get<HotelTableViewModel>();

        public PayedTourTableViewModel PayedTourTableViewModel => kernel.Get<PayedTourTableViewModel>();

        public PostTableViewModel PostTableViewModel => kernel.Get<PostTableViewModel>();

        public SightTableViewModel SightTableViewModel => kernel.Get<SightTableViewModel>();

        public TourVisitTableViewModel TourVisitTableViewModel => kernel.Get<TourVisitTableViewModel>();

        public TransportTableViewModel TransportTableViewModel => kernel.Get<TransportTableViewModel>();

        public UserToursListViewModel UserToursListViewModel => kernel.Get<UserToursListViewModel>();

        public WorkerTableViewModel WorkerTableViewModel => kernel.Get<WorkerTableViewModel>();

        public OrderConfirmationViewModel OrderConfirmationViewModel => kernel.Get<OrderConfirmationViewModel>();

        public TourOrderingViewModel TourOrderingViewModel => kernel.Get<TourOrderingViewModel>();
    }
}
