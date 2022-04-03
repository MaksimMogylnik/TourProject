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
    class ClientTableViewModel : BaseNotifyPropertyChanged
    {
        public ClientService clientService;
        public ObservableCollection<ClientDTO> Clients { get; set; }

        private ClientDTO selectedClient;
        public ClientDTO SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                NotifyOfPopertyChanged();
            }
        }

        public ClientTableViewModel(ClientService service)
        {
            clientService = service;
            Clients = new ObservableCollection<ClientDTO>(clientService.GetAll());

            SaveChangesCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => clientService.CreateOrUpdate(SelectedClient));
            });

            DeleteCommand = new RelayCommand(async param =>
            {
                await Task.Factory.StartNew(()
                    => clientService.Delete(SelectedClient));
            });
        }

        public ICommand SaveChangesCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }
    }
}
