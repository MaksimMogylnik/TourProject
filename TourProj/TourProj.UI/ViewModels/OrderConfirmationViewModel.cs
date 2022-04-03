using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourProj.BLL.DTO;
using TourProj.BLL.Services;
using TourProj.UI.Infrastructure;
using TourProj.UI.Models;
using TourProj.UI.Views;

namespace TourProj.UI.ViewModels
{
    class OrderConfirmationViewModel
    {
        ClientService clientService;
        PayedTourService payedTourService;
        public TourDTO SelectedTour { get; set; }

        public string ClientName { get; set; }

        public OrderConfirmationViewModel(ClientService service1, PayedTourService service2)
        {
            clientService = service1;
            payedTourService = service2;
            SelectedTour = SelectedFullTourInfoModel.SelectedFullTourInfo;

            BackCommand = new RelayCommand(param => Switcher.Switch(new UserToursListView()));

            OrderCommand = new RelayCommand(param =>
            {
                foreach(ClientDTO client in clientService.GetAll())
                {
                    if (ClientName == client.ClientFullName)
                    {
                        payedTourService.CreateOrUpdate(new PayedTourDTO()
                        {
                            TourID = SelectedTour.TourID,
                            ClientID = client.ClientID,
                            Payment = SelectedTour.Cost
                        });

                        MessageBox.Show("Payment Saved!",
                            "Info",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                        return;
                    }

                    MessageBox.Show("Uncknown client! Register him first",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                }
            });
        }

        public ICommand BackCommand { get; set; }

        public ICommand OrderCommand { get; set; }
    }
}
