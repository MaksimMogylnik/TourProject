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
    class ArchiveTourTableViewModel : BaseNotifyPropertyChanged
    {
        public ArchiveService archiveService;
        public ObservableCollection<ArchiveDTO> ArchiveTours { get; set; }

        private ArchiveDTO selectedArchiveTour;
        public ArchiveDTO SelectedArchiveTour
        {
            get => selectedArchiveTour;
            set
            {
                selectedArchiveTour = value;
                NotifyOfPopertyChanged();
            }
        }

        public ArchiveTourTableViewModel(ArchiveService service)
        {
            archiveService = service;
            ArchiveTours = new ObservableCollection<ArchiveDTO>(archiveService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => archiveService.CreateOrUpdate(SelectedArchiveTour));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => archiveService.Delete(SelectedArchiveTour));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
