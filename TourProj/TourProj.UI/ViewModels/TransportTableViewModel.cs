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

namespace TourProj.UI.ViewModels
{
    class TransportTableViewModel : BaseNotifyPropertyChanged
    {
        public TransportService transportService;
        public ObservableCollection<TransportDTO> Transport { get; set; }

        private TransportDTO selectedTransport;
        public TransportDTO SelectedTransport 
        {
            get => selectedTransport;
            set
            {
                selectedTransport = value;
                NotifyOfPopertyChanged();
            }
        }

        public TransportTableViewModel(TransportService service)
        {
            transportService = service;
            Transport = new ObservableCollection<TransportDTO>(transportService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => transportService.CreateOrUpdate(SelectedTransport));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => transportService.Delete(SelectedTransport));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
