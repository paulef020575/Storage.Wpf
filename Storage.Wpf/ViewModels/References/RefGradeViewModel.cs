using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    class RefGradeViewModel : ReferenceViewModel<Grade, GradeViewModel>
    {
        public override string Title => "Справочник сортов";
    }
}
