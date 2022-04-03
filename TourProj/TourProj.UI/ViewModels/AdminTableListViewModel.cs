using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourProj.UI.Infrastructure;
using TourProj.UI.Views;

namespace TourProj.UI.ViewModels
{
    class AdminTableListViewModel
    {
        public AdminTableListViewModel()
        {
            InitCommands();
        }

        public void InitCommands()
        {
            GetAdminTourTable = new RelayCommand(param =>
            {
                Switcher.Switch(new AdminTourTableView());
            });

            GetAcrhiveTourTable = new RelayCommand(param =>
            {
                Switcher.Switch(new AcrhiveTourTableView());
            });

            GetCityTable = new RelayCommand(param =>
            {
                Switcher.Switch(new CityTableView());
            });

            GetClientTable = new RelayCommand(param =>
            {
                Switcher.Switch(new ClientTableView());
            });

            GetCountryTable = new RelayCommand(param =>
            {
                Switcher.Switch(new CountryTableView());
            });

            GetHotelTable = new RelayCommand(param =>
            {
                Switcher.Switch(new HotelTableView());
            });

            GetPayedTourTable = new RelayCommand(param =>
            {
                Switcher.Switch(new PayedTourTableView());
            });

            GetPostTable = new RelayCommand(param =>
            {
                Switcher.Switch(new PostTableView());
            });

            GetSightTable = new RelayCommand(param =>
            {
                Switcher.Switch(new SightTableView());
            });

            GetTourVisitTable = new RelayCommand(param =>
            {
                Switcher.Switch(new TourVisitTableView());
            });

            GetTransportTable = new RelayCommand(param =>
            {
                Switcher.Switch(new TransportTableView());
            });

            GetWorkerTable = new RelayCommand(param =>
            {
                Switcher.Switch(new WorkerTableView());
            });

            SetUserList = new RelayCommand(param =>
            {
                Switcher.Switch(new UserToursListView());
            });
        }


        public ICommand GetAdminTourTable { get; private set; }
        public ICommand GetAcrhiveTourTable { get; private set; }
        public ICommand GetCityTable { get; private set; }
        public ICommand GetClientTable { get; private set; }
        public ICommand GetCountryTable { get; private set; }
        public ICommand GetHotelTable { get; private set; }
        public ICommand GetPayedTourTable { get; private set; }
        public ICommand GetPostTable { get; private set; }
        public ICommand GetSightTable { get; private set; }
        public ICommand GetTourVisitTable { get; private set; }
        public ICommand GetTransportTable { get; private set; }
        public ICommand GetWorkerTable { get; private set; }
        public ICommand SetUserList { get; private set; }

    }
}
