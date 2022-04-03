using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TourProj.BLL.Services;
using TourProj.UI.Infrastructure;
using TourProj.UI.Views;

namespace TourProj.UI.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        private UserControl currentPage;
        public UserControl CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                NotifyOfPopertyChanged();
            }
        }
        public MainViewModel()
        {
            CurrentPage = new UserToursListView();
            InitCommands();
            Switcher.ContentArea = this;
        }

        public void InitCommands()
        {
            SetAdminCommand = new RelayCommand(param =>
            {
                Switcher.Switch(new AdminTableListView());
            });
        }


        public ICommand SetAdminCommand { get; private set; }


        public void Navigate(UserControl page)
        {
            CurrentPage = page;
        }
    }
}
