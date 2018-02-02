using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class TypeProdViewModel : EntityViewModel<TypeProd>
    {
        #region Properties

        private TypeProd typeProd { get { return Entity; } }

        [Column("Код", Width = 50)]
        public int Code
        {
            get { return typeProd.Code; }
            set
            {
                if (typeProd.Code != value)
                {
                    typeProd.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        [Column("Код внешней системы")]
        public string ExternalCode
        {
            get { return typeProd.ExternalCode; }
            set
            {
                if (typeProd.ExternalCode != value)
                {
                    typeProd.ExternalCode = value;
                    OnPropertyChanged("ExternalCode");
                }
            }
        }

        [Column("Наименование", Width = 250, Position = 0)]
        public string Name
        {
            get { return typeProd.Name; }
            set
            {
                if (typeProd.Name != value)
                {
                    typeProd.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        [Browsable(false)]
        public override string Title => Name;

        #endregion


    }
}
