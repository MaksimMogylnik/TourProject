using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TourProj.BLL.DTO;
using TourProj.BLL.Services;
using TourProj.UI.Infrastructure;
using TourProj.UI.Models;
using TourProj.UI.Views;

namespace TourProj.UI.ViewModels
{
    class TourOrderingViewModel
    {
        public TourDTO SelectedTour { get; set; }

        public WorkerDTO Worker { get; set; }

        public SightDTO Sight { get; set; }

        public CityDTO City { get; set; }

        public CountryDTO Country { get; set; }

        public TransportDTO Transport { get; set; }

        public HotelDTO Hotel { get; set; }

        public TourVisitDTO TourVisit { get; set; }

        public TourOrderingViewModel(WorkerService workerService,
            TransportService transportService,
            SightService sightService,
            CityService cityService,
            CountryService countryService,
            HotelService hotelService,
            TourVisitService tourVisitService)
        {
            SelectedTour = SelectedFullTourInfoModel.SelectedFullTourInfo;

            #region

            Worker = workerService.GetAll()
                .Where(w => w.Tours.Contains(SelectedTour))
                .FirstOrDefault();

            Transport = transportService.GetAll()
                .Where(w => w.TransportID == SelectedTour.TransportID)
                .FirstOrDefault();

            TourVisit = tourVisitService.GetAll()
                .Where(w => w.TourID == SelectedTour.TourID)
                .FirstOrDefault();

            City = cityService.GetAll()
                .Where(w => w.CityID == TourVisit.CityID)
                .FirstOrDefault();

            Country = countryService.GetAll()
                .Where(w => w.CoutryID == TourVisit.CoutryID)
                .FirstOrDefault();

            Sight = sightService.GetAll()
                .Where(w => w.CityID == City.CityID &&
                w.CoutryID == Country.CoutryID)
                .FirstOrDefault();

            Hotel = hotelService.GetAll()
                .Where(w => w.HotelID == TourVisit.HotelID)
                .FirstOrDefault();

            #endregion

            BackCommand = new RelayCommand(param => Switcher.Switch(new UserToursListView()));

            OrderCommand = new RelayCommand(param => Switcher.Switch(new OrderConfirmationView()));
        }

        public ICommand BackCommand { get; set; }

        public ICommand OrderCommand { get; set; }
    }
}
