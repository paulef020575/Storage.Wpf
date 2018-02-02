using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class RefStoreViewModel : ReferenceViewModel<Store, StoreViewModel>
    {
        public override string Title => "Справочник складов";

        private List<Enumeration> storeTypeEnumeration;

        public List<Enumeration> StoreTypeEnumeration
        {
            get
            {
                if (storeTypeEnumeration == null)
                    storeTypeEnumeration = SessionManager.Instance.GetEnumeration("StoreType");

                return storeTypeEnumeration;
            }
        }

        protected override StoreViewModel CreateItemViewModel()
        {
            return new StoreViewModel(StoreTypeEnumeration);
        }
    }
}
