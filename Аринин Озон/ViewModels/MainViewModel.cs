using System.Collections.ObjectModel;
using System.Windows.Input;

using Аринин_Озон.Commands;
using Аринин_Озон.Controllers;
using Аринин_Озон.Models;

namespace Аринин_Озон.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Order> Orders { get; } = new ObservableCollection<Order>();
        public Order? SelectedOrder { get; set; }

        public ICommand OpenOrderDetailsCommand { get; }

        private readonly NavigationService _navigationService;

        public MainViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            // Инициализация тестовых данных
            Orders.Add(new Order { Id = 1, CustomerName = "Арина", Status = "Новый" });
            Orders.Add(new Order { Id = 2, CustomerName = "Арина 2", Status = "В Обработке" });

            OpenOrderDetailsCommand = new RelayCommand(OpenOrderDetails, () => SelectedOrder != null);
        }

        private void OpenOrderDetails()
        {
            if (SelectedOrder != null)
            {
                var detailsViewModel = new OrderDetailsViewModel(SelectedOrder, _navigationService);
                _navigationService.NavigateTo(detailsViewModel);
            }
        }
    }
}
