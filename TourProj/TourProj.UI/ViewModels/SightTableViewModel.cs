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
    class SightTableViewModel : BaseNotifyPropertyChanged
    {
        public SightService sightService;
        public ObservableCollection<SightDTO> Sights { get; set; }

        private SightDTO selectedSight;
        public SightDTO SelectedSight
        {
            get => selectedSight;
            set
            {
                selectedSight = value;
                NotifyOfPopertyChanged();
            }
        }

        public SightTableViewModel(SightService service)
        {
            sightService = service;
            Sights = new ObservableCollection<SightDTO>(sightService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => sightService.CreateOrUpdate(SelectedSight));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => sightService.Delete(SelectedSight));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
