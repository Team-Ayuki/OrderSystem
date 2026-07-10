using OrderSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Model
{
    public interface INavigationService
    {
        public IPageViewModel CurrentViewModel { get; set; } 
        public EventHandler? CurrentViewModelChanged { get; set; }

        public void NavigateTo(string pageKey);
    }
}
