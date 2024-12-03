using System;
using System.Collections.Generic;

namespace Аринин_Озон.Controllers
{
    public class NavigationService
    {
        private readonly Stack<object> _navigationStack = new Stack<object>();

        public Action<object>? OnNavigate { get; set; }

        public void NavigateTo(object viewModel)
        {
            _navigationStack.Push(viewModel);
            OnNavigate?.Invoke(viewModel);
        }

        public void GoBack()
        {
            if (_navigationStack.Count > 1)
            {
                _navigationStack.Pop();
                OnNavigate?.Invoke(_navigationStack.Peek());
            }
        }
    }
}
