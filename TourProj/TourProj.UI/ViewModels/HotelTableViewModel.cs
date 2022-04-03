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
    class HotelTableViewModel : BaseNotifyPropertyChanged
    {
        public HotelService hotelService;
        public ObservableCollection<HotelDTO> Hotels { get; set; }

        private HotelDTO selectedHotel;
        public HotelDTO SelectedHotel
        {
            get => selectedHotel;
            set
            {
                selectedHotel = value;
                NotifyOfPopertyChanged();
            }
        }

        public HotelTableViewModel(HotelService service)
        {
            hotelService = service;
            Hotels = new ObservableCollection<HotelDTO>(hotelService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => hotelService.CreateOrUpdate(SelectedHotel));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => hotelService.Delete(SelectedHotel));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
