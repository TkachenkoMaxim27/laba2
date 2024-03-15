using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp3.View;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = new MainWindow(); // Создаем экземпляр главного окна или контейнера, например, MainWindow
            var loginControl = new LoginWindow(); // Создаем экземпляр UserControl, например, LoginUserControl
            mainWindow.Content = loginControl; // Устанавливаем UserControl в качестве содержимого главного окна
            mainWindow.Show(); // Показываем главное окно с UserControl при запуске приложения
        }
    }
}
