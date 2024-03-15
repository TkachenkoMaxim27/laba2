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
    internal class UserViewModel : INotifyPropertyChanged

    {
        public Products _product;
        public System.Windows.Input.ICommand ExitCommand { get; }
        public System.Windows.Input.ICommand NavigateCommand { get; }
        public System.Windows.Input.ICommand ChangeQuantityCommand { get; }
       
        public Products SelectedProduct { get; set; }

        public UserViewModel(Products products)
        {
           
           // ChangeQuantityCommand = new RelayCommand(ExecuteChangeQuantity, CanExecuteChangeQuantity);
           

            _product = products;

        }
        public UserViewModel()
        {
            ExitCommand = new ICommand(ExecuteExit, CanExecuteExit);
            NavigateCommand = new ICommand(ExecuteNavigate, CanExecuteNavigate);
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
    private void ExecuteExit(object parameter)
        {
            var mainWindow = new MainWindow();
            var logControl = new LoginWindow();
            mainWindow.Content = logControl;
            mainWindow.Show();
        }

        private bool CanExecuteExit(object parameter)
        {
            return true;
        }

        private void ExecuteNavigate(object parameter)
        {
            var mainWindow = new MainWindow();
            var OrderControl = new ShowOrderForUser();
            mainWindow.Content = OrderControl;
            mainWindow.Show();
        }
      
        private bool CanExecuteNavigate(object parameter)
        {
            return true;
        }

        /*private void ExecuteChangeQuantity(object parameter)
        {
            if (SelectedProduct != null)
            {
                
                if (parameter is string newQuantity)
                {
                    SelectedProduct.Kollichestvo = newQuantity;
                    Console.WriteLine("Команда изменения количества выполнена. Новое количество: " + newQuantity);
                }
            }
        }

        private bool CanExecuteChangeQuantity(object parameter)
        {
            return SelectedProduct != null;
        }*/
    }
    public class ICommand : System.Windows.Input.ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public ICommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public static implicit operator ICommand(RelayCommand v)
        {
            throw new NotImplementedException();
        }
    }
}
