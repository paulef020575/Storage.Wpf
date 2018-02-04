using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class RefCustomerViewModel : ReferenceViewModel<Customer, CustomerViewModel>
    {
        public override string Title
        {
            get
            {
                return "Справочник контрагентов";
            }
        }
    }
}
