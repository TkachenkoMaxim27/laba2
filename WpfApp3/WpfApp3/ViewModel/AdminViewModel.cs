using System;
using System.ComponentModel;
using WpfApp3.Model;
using WpfApp3.View;
using System.Windows.Input;

namespace WpfApp3.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommand { get; set; }
        public ICommand NavigatePVZCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand GoHomeNavigateCommand { get; set; }
        public ICommand ChangeCommand { get; set; }


        public Products _product;
        public AdminViewModel(Products products)
        {
            
            _product = products;
        }
        public AdminViewModel()
        {
           AddCommand = new RelayCommand(Add);
            NavigatePVZCommand = new RelayCommand(NavigatePVZ);
            DeleteCommand = new RelayCommand(Delete);
            GoHomeNavigateCommand = new RelayCommand(GoHome);
            ChangeCommand = new RelayCommand(Change);
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
        private void Add(object parameter)
        {
            var mainWindow = new MainWindow();
            var AddControl = new AddAdminControl();
            mainWindow.Content = AddControl;
            mainWindow.Show();
        }

        private void NavigatePVZ(object parameter)
        {
            var mainWindow = new MainWindow();
            var PvzControl = new ShowPvzAdmin();
            mainWindow.Content = PvzControl;
            mainWindow.Show();
        }

        private void Delete(object parameter)
        {
            var mainWindow = new MainWindow();
            var DelControl = new DeleteAdminControl1();
            mainWindow.Content = DelControl;
            mainWindow.Show();
        }

        private void GoHome(object parameter)
        {
            var mainWindow = new MainWindow();
            var logControl = new LoginWindow();
            mainWindow.Content = logControl;
            mainWindow.Show();
        }

        private void Change(object parameter)
        {
            var mainWindow = new MainWindow();
            var ChangeControl = new ChangeAdminControl();
            mainWindow.Content = ChangeControl;
            mainWindow.Show();
        }
    }
    public class RelayCommand : System.Windows.Input.ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute(parameter);

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

