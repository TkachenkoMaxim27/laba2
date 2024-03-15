
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp3.Model;
using WpfApp3.View;

namespace WpfApp3.ViewModel
{
    public class UserOrderViewModel : INotifyPropertyChanged
    {
        public Orders _orders;
        public System.Windows.Input.ICommand HomeNavigateCommand { get; }

        public UserOrderViewModel(Orders orders)
        {
        
            _orders = orders;
        }
        public UserOrderViewModel()
        {
            //HomeNavigateCommand = new RelayCommand(HomeNavigate);
        }
        public int ID
        {
            get { return _orders.Id; }
            set
            {
                if (_orders.Id != value)
                {
                    _orders.Id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }
        public Client Client
        {
            get { return _orders.FK_Client; }
            set
            {
                if (_orders.FK_Client != value)
                {
                    _orders.FK_Client = value;
                    OnPropertyChanged(nameof(Client));
                }
            }
        }
        public PickupPoints pickupPoint
        {
            get { return _orders.FK_PickupPoint; }
            set
            {
                if (_orders.FK_PickupPoint != value)
                {
                    _orders.FK_PickupPoint = value;
                    OnPropertyChanged(nameof(pickupPoint));
                }
            }
        }
        public DateTime Date
        {
            get { return _orders.date; }
            set
            {
                if (_orders.date != value)
                {
                    _orders.date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        private void HomeNavigate()
        {
            var mainWindow = new MainWindow();
            var BackControl = new ShopForUser();
            mainWindow.Content = BackControl;
            mainWindow.Show();
            throw new NotImplementedException();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   
}
