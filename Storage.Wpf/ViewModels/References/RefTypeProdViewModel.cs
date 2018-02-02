using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class RefTypeProdViewModel : ReferenceViewModel<TypeProd, TypeProdViewModel>
    {
        public override string Title => "Справочник видов продукции";
    }
}
