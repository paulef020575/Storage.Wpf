using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class CustomerViewModel : EntityViewModel<Customer>
    {
        #region Properties

        public Customer Customer => Entity as Customer;

        public override string Title
        {
            get
            {
                return Customer.ToString();
            }
        }

        [Column("Код", Width = 50)]
        public int Code
        {
            get { return Customer.Code; }
            set
            {
                if (Customer.Code != value)
                {
                    Customer.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        [Column("Код внешней системы")]
        public string ExternalCode
        {
            get { return Customer.ExternalCode; }
            set
            {
                if (Customer.ExternalCode != value)
                {
                    Customer.ExternalCode = value;
                    OnPropertyChanged("ExternalCode");
                }
            }
        }

        [Column("Наименование", Position = 0, Width = 250)]
        public string Name
        {
            get { return Customer.Name; }
            set
            {
                if (Customer.Name != value)
                {
                    Customer.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        #endregion
    }
}
