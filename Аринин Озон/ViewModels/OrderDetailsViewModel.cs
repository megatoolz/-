using System.Windows.Input;

using Аринин_Озон.Commands;
using Аринин_Озон.Controllers;
using Аринин_Озон.Models;

namespace Аринин_Озон.ViewModels
{
    public class OrderDetailsViewModel
    {
        public string Title { get; } = "Детали заказа";
        public Order Order { get; }

        public ICommand GoBackCommand { get; }
        public ICommand MarkAsDeliveredCommand { get; }
        public ICommand MarkAsReturnedCommand { get; }

        public OrderDetailsViewModel(Order order, NavigationService navigationService)
        {
            Order = order;

            GoBackCommand = new RelayCommand(() => navigationService.GoBack());
            MarkAsDeliveredCommand = new RelayCommand(MarkAsDelivered);
            MarkAsReturnedCommand = new RelayCommand(MarkAsReturned);
        }

        private void MarkAsDelivered()
        {
            Order.IsDelivered = true;
            Order.Status = "Доставлен";
        }

        private void MarkAsReturned()
        {
            Order.IsReturned = true;
            Order.Status = "Возвращен";
        }
    }
}
