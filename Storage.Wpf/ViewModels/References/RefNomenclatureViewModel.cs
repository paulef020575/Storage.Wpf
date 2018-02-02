using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class RefNomenclatureViewModel : ReferenceViewModel<Nomenclature, NomenclatureViewModel>
    {
        public override string Title => "Справочник номенклатуры";
    }
}
