using System.Windows;

using Аринин_Озон.Controllers;
using Аринин_Озон.ViewModels;
using Аринин_Озон.Views;

namespace Аринин_Озон
{
    public partial class App : Application
    {
        private readonly NavigationService _navigationService = new NavigationService();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаём главное окно
            var mainWindow = new MainWindow();
            var mainViewModel = new MainViewModel(_navigationService);

            // Настраиваем главное окно как стартовое
            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();

            // Настраиваем навигацию
            _navigationService.OnNavigate = viewModel =>
            {
                if (viewModel is OrderDetailsViewModel detailsViewModel)
                {
                    var detailsWindow = new OrderDetailsView { DataContext = detailsViewModel };
                    detailsWindow.ShowDialog(); // Открываем модальное окно
                }
            };
        }
    }
}
