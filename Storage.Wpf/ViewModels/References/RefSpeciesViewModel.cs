using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class RefSpeciesViewModel : ReferenceViewModel<Species, SpeciesViewModel>
    {
        public override string Title => "Справочник пород";
    }
}
