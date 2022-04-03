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
    class CityTableViewModel : BaseNotifyPropertyChanged
    {
        public CityService cityService;
        public ObservableCollection<CityDTO> Cities { get; set; }

        private CityDTO selectedCity;
        public CityDTO SelectedCity
        {
            get => selectedCity;
            set
            {
                selectedCity = value;
                NotifyOfPopertyChanged();
            }
        }

        public CityTableViewModel(CityService service)
        {
            cityService = service;
            Cities = new ObservableCollection<CityDTO>(cityService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => cityService.CreateOrUpdate(SelectedCity));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => cityService.Delete(SelectedCity));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
