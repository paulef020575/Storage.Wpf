using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class SpeciesViewModel : EntityViewModel<Species>
    {
        #region Properties

        public Species Species => Item as Species;

        [Column("Код", Width = 50)]
        public int Code
        {
            get { return Species.Code; }
            set
            {
                if (Species.Code != value)
                {
                    Species.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        [Column("Код внешней системы")]
        public string ExternalCode
        {
            get { return Species.ExternalCode; }
            set
            {
                if (Species.ExternalCode != value)
                {
                    Species.ExternalCode = value;
                    OnPropertyChanged("Species");
                }
            }
        }

        [Column("Наименование", Width = 250, Position = 0)]
        public string Name
        {
            get { return Species.Name; }
            set
            {
                if (Species.Name != value)
                {
                    Species.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public override string Title => Name;

        #endregion
    }
}
