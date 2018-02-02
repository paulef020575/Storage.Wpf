using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class GradeViewModel : EntityViewModel<Grade>
    {
        #region Properties

        private Grade Grade { get { return Item as Grade; } }

        [Column("Код", Width = 50)]
        public int Code
        {
            get { return Grade.Code; }
            set
            {
                if (Grade.Code != value)
                {
                    Grade.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        [Column("Код внешней системы")]
        public string ExternalCode
        {
            get { return Grade.ExternalCode; }
            set
            {
                if (Grade.ExternalCode != value)
                {
                    Grade.ExternalCode = value;
                    OnPropertyChanged("ExternalCode");
                }
            }
        }

        [Column("Наименование", Width = 250, Position = 0)]
        public string Name
        {
            get { return Grade.Name; }
            set
            {
                if (Grade.Name != value)
                {
                    Grade.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        
        [Column("высший сорт", Width = 50)]
        public bool Top
        {
            get { return Grade.IsTop; }
            set
            {
                if (Grade.IsTop != value)
                {
                    Grade.IsTop = value;
                    OnPropertyChanged("Top");
                }
            }
        }

        #endregion
    }
}
