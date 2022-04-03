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
    class WorkerTableViewModel : BaseNotifyPropertyChanged
    {
        public WorkerService workerService;
        public ObservableCollection<WorkerDTO> Workers { get; set; }

        private WorkerDTO selectedWorker;
        public WorkerDTO SelectedWorker
        {
            get => selectedWorker;
            set
            {
                selectedWorker = value;
                NotifyOfPopertyChanged();
            }
        }

        public WorkerTableViewModel(WorkerService service)
        {
            workerService = service;
            Workers = new ObservableCollection<WorkerDTO>(workerService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => workerService.CreateOrUpdate(SelectedWorker));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => workerService.Delete(SelectedWorker));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
