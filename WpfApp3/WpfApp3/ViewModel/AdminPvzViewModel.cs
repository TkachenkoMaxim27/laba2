using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;

namespace WpfApp3.ViewModel
{
    internal class AdminPvzViewModel : INotifyPropertyChanged
    {
        public PickupPoints _pickupPoints;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdminPvzViewModel(PickupPoints points)
        {

            _pickupPoints = points;
        }
        public AdminPvzViewModel()
        {

            
        }
        public int ID
        {
            get { return _pickupPoints.Id; }
            set
            {
                if (_pickupPoints.Id != value)
                {
                    _pickupPoints.Id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }
        public string Adress
        {
            get { return _pickupPoints.Address; }
            set
            {
                if (_pickupPoints.Address != value)
                {
                    _pickupPoints.Address = value;
                    OnPropertyChanged(nameof(Adress));
                }
            }
        }
        public string Phone
        {
            get { return _pickupPoints.Phone; }
            set
            {
                if (_pickupPoints.Phone != value)
                {
                    _pickupPoints.Phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
   
}
