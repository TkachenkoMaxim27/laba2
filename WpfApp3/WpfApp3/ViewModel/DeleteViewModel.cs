using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Model;
using WpfApp3.View;

namespace WpfApp3.ViewModel
{
    public class DeleteViewModel: INotifyPropertyChanged
    {
        public Products _product;

        public ICommand DelCommand { get; set; }
        public ICommand BackCommand { get; set; }

        public DeleteViewModel(Products products)
        {

            _product = products;
        }
        public DeleteViewModel()
        {
            DelCommand = new RelayCommand(Del);
            BackCommand = new RelayCommand(NBackPVZ);
        }
        public int ID
        {
            get { return _product.Id; }
            set
            {
                if (_product.Id != value)
                {
                    _product.Id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }
        public string Name
        {
            get { return _product.Title; }
            set
            {
                if (_product.Title != value)
                {
                    _product.Title = value;
                    OnPropertyChanged(nameof(_product.Title));
                }
            }
        }
        public decimal Rating
        {
            get { return _product.Rating; }
            set
            {
                if (_product.Rating != value)
                {
                    _product.Rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }
        }
        public string Kollichestvo
        {
            get { return _product.Kollichestvo; }
            set
            {
                if (_product.Kollichestvo != value)
                {
                    _product.Kollichestvo = value;
                    OnPropertyChanged(nameof(Kollichestvo));
                }
            }
        }

        public decimal Price
        {
            get { return _product.Price; }
            set
            {
                if (_product.Price != value)
                {
                    _product.Price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Del(object parameter)
        {
            var mainWindow = new MainWindow();
            var Back1Control = new ShopForAdmin();
            mainWindow.Content = Back1Control;
            mainWindow.Show();
        }

        private void NBackPVZ(object parameter)
        {
            var mainWindow = new MainWindow();
            var Back2Control = new ShopForAdmin();
            mainWindow.Content = Back2Control;
            mainWindow.Show();
        }
    }
}
