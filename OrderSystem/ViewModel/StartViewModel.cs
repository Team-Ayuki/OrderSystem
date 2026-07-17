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
    public class StartViewModel : ViewModelBase, IPageViewModel
    {
        private string _title = "Start";
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }
        INavigationService nav;

        public ICommand StartCommand { get; set; }

        public StartViewModel(INavigationService nav)
        {
            this.nav = nav;
            StartCommand = new RelayCommand<object>(o => StartCommandExecute());
        }
        private void StartCommandExecute()
        {
            nav.NavigateTo("Order");
        }
    }
}
