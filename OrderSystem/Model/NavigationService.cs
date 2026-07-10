using OrderSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public class NavigationService : INavigationService
    {
        public IPageViewModel CurrentViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EventHandler? CurrentViewModelChanged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }
    }
}
