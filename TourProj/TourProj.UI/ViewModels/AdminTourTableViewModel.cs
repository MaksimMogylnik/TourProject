using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourProj.BLL.DTO;
using TourProj.BLL.Services;
using TourProj.UI.Infrastructure;

namespace TourProj.UI.ViewModels
{
    class AdminTourTableViewModel : BaseNotifyPropertyChanged
    {
        public TourService tourService;
        public ObservableCollection<TourDTO> Tours { get; set; }

        private TourDTO selectedTour;
        public TourDTO SelectedTour
        {
            get => selectedTour;
            set
            {
                selectedTour = value;
                NotifyOfPopertyChanged();
            }
        }

        public AdminTourTableViewModel(TourService service)
        {
            tourService = service;
            Tours = new ObservableCollection<TourDTO>(tourService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => tourService.CreateOrUpdate(SelectedTour));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => tourService.Delete(SelectedTour));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
