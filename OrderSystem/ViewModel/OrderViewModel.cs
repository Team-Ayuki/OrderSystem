using OrderSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.ViewModel
{
    class OrderViewModel: ViewModelBase,IPageViewModel
    {
        private string _title = "CheckOut";
        public string Title
        {
            get => _title;
            set => SetField(ref _title, value);
        }
    }
}
