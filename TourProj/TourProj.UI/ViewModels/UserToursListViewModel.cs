using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourProj.BLL.DTO;
using TourProj.BLL.Services;
using TourProj.DAL.Repositories;
using TourProj.UI.Infrastructure;
using TourProj.UI.Models;
using TourProj.UI.Views;

namespace TourProj.UI.ViewModels
{
    class UserToursListViewModel
    {
        public TourService tourService;
        public ObservableCollection<TourDTO> Tours { get; set; }

        public TourDTO SelectedTour { get; set; }

        public UserToursListViewModel(TourService service)
        {
            tourService = service;
            Tours = new ObservableCollection<TourDTO>(tourService.GetAll());

            ExtendedInfo = new RelayCommand(param =>
            {
                SelectedFullTourInfoModel.SelectedFullTourInfo = SelectedTour;
                Switcher.Switch(new TourOrderingView());
            });
        }

        public ICommand ExtendedInfo { get; set; }
    }
}
