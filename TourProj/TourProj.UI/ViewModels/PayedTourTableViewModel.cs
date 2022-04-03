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
    class PayedTourTableViewModel : BaseNotifyPropertyChanged
    {
        public PayedTourService payedTourService;
        public ObservableCollection<PayedTourDTO> PayedTours { get; set; }

        private PayedTourDTO selectedPayedTour;
        public PayedTourDTO SelectedPayedTour
        {
            get => selectedPayedTour;
            set
            {
                selectedPayedTour = value;
                NotifyOfPopertyChanged();
            }
        }

        public PayedTourTableViewModel(PayedTourService service)
        {
            payedTourService = service;
            PayedTours = new ObservableCollection<PayedTourDTO>(payedTourService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => payedTourService.CreateOrUpdate(SelectedPayedTour));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => payedTourService.Delete(SelectedPayedTour));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
