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
        private readonly Dictionary<string, Func<IPageViewModel>> _factories = new();
        public IPageViewModel CurrentViewModel 
        {   get => _current; 
        }
        IPageViewModel INavigationService.CurrentViewModel { get => CurrentViewModel; set => throw new NotImplementedException(); }
        public event EventHandler? CurrentViewModelChanged;

        private IPageViewModel? _current;

        public void Register(string Key, Func<IPageViewModel> factory)
        {
            _factories[Key] = factory;
        }
        
        public void NavigateTo(string pageKey)
        {
            _current = _factories[pageKey]();
            CurrentViewModelChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
