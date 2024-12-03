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

            var mainWindow = new MainWindow();
            var mainViewModel = new MainViewModel(_navigationService);

            _navigationService.OnNavigate = viewModel =>
            {
                if (viewModel is OrderDetailsViewModel)
                {
                    var detailsWindow = new OrderDetailsView { DataContext = viewModel };
                    detailsWindow.Show();
                }
                else
                {
                    mainWindow.DataContext = viewModel;
                }
            };

            _navigationService.NavigateTo(mainViewModel);

            mainWindow.Show();
        }
    }
}
