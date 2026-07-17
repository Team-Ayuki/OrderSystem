using OrderSystem.Common;
using OrderSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace OrderSystem.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navService;

        public IPageViewModel CurrentViewModel => _navService.CurrentViewModel;
        public ICommand NavigateCommand { get; }

        public MainViewModel(INavigationService navService)
        {
            _navService = navService;
            _navService.CurrentViewModelChanged += (_, _) => OnPropertyChanged(nameof(CurrentViewModel));
            NavigateCommand = new RelayCommand<string>(key => _navService.NavigateTo((string)key!));

            _navService.NavigateTo("Start"); // 初期画面
        }
    }
}
