using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.View;
using WpfApp3.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp3.ViewModel
{
    public class AuthorizationViewModel : INotifyPropertyChanged
    {
        public Employes _employes;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Login
        {
            get { return _employes.Login; }
            set
            {
                if (_employes.Login != value)
                {
                    _employes.Login = value;
                    OnPropertyChanged(nameof(Login));
                }
            }
        }

        public string Password
        {
            get { return _employes.Password; }
            set
            {
                if (_employes.Password != value)
                {
                    _employes.Password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public System.Windows.Input.ICommand AuthorizeCommand { get; }

        public AuthorizationViewModel(Employes employes)
        {
            
            _employes = employes;
        }
        public AuthorizationViewModel()
        {
            AuthorizeCommand = new RelayCommand(OnAuthorize);
        }

        public void OnAuthorize(object parameter)
        {
            if ( Login == "admin" && Password == "1234p")
            {
                var mainWindow = new MainWindow(); 
                var loginControl = new ShopForAdmin(); 
                mainWindow.Content = loginControl; 
                mainWindow.Show();
            }
             else if (Login == "user" && Password == "123p")
            {
                var mainWindow = new MainWindow();
                var loginControl = new ShopForUser();
                mainWindow.Content = loginControl;
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
}
