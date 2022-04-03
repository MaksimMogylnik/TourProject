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
    class CountryTableViewModel : BaseNotifyPropertyChanged
    {
        public CountryService countryService;
        public ObservableCollection<CountryDTO> Countries { get; set; }

        private CountryDTO selectedCountry;
        public CountryDTO SelectedCountry
        {
            get => selectedCountry;
            set
            {
                selectedCountry = value;
                NotifyOfPopertyChanged();
            }
        }

        public CountryTableViewModel(CountryService service)
        {
            countryService = service;
            Countries = new ObservableCollection<CountryDTO>(countryService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => countryService.CreateOrUpdate(SelectedCountry));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => countryService.Delete(SelectedCountry));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
