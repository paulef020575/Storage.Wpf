using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class RoadViewModel : EntityViewModel<Road>
    {
        #region Properties

        public Road Road => Entity as Road;

        [Column("Код прохода")]
        public string Code
        {
            get { return Road.Code; }
            set
            {
                if (Road.Code != value)
                {
                    Road.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        [Column("заблокирована", Width = 75)]
        public bool Blocked
        {
            get { return Road.Blocked; }
            set
            {
                if (Road.Blocked != value)
                {
                    Road.Blocked = value;
                    OnPropertyChanged("Blocked");
                }
            }
        }

        public override string Title => "Дорога " + Code;

        #endregion
    }
}
