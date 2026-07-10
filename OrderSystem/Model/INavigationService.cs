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
        IPageViewModel CurrentViewModel { get; set; }
        event EventHandler? CurrentViewModelChanged;

        void NavigateTo(string pageKey);
    }
}
