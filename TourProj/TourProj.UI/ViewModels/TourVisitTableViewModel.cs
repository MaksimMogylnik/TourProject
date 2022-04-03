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
    class TourVisitTableViewModel : BaseNotifyPropertyChanged
    {
        public TourVisitService tourVisitService;
        public ObservableCollection<TourVisitDTO> TourVisits { get; set; }

        private TourVisitDTO selectedTourVisit;
        public TourVisitDTO SelectedTourVisit
        {
            get => selectedTourVisit;
            set
            {
                selectedTourVisit = value;
                NotifyOfPopertyChanged();
            }
        }

        public TourVisitTableViewModel(TourVisitService service)
        {
            tourVisitService = service;
            TourVisits = new ObservableCollection<TourVisitDTO>(tourVisitService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => tourVisitService.CreateOrUpdate(SelectedTourVisit));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => tourVisitService.Delete(SelectedTourVisit));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
