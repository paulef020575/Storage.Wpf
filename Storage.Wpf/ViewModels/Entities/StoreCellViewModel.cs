using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.Classes;

namespace Storage.Wpf
{
    public class StoreCellViewModel : EntityViewModel<StoreCell>
    {
        #region Properties

        public override string Title => (StoreCell == null ? "не размечена" : StoreCell.Name);

        public StoreCell StoreCell => Entity as StoreCell;

        public bool IsCell => (StoreCell != null);

        private int rowPosition;

        public int RowPosition
        {
            get { return (StoreCell == null ? rowPosition : StoreCell.X); }
            set
            {
                if (StoreCell != null && StoreCell.X != value)
                {
                    StoreCell.X = value;
                    OnPropertyChanged("RowPosition");
                }
            }
        }

        private int columnPosition;
        public int ColumnPosition
        {
            get { return (StoreCell == null ? columnPosition : StoreCell.Y); }
            set
            {
                if (StoreCell != null && StoreCell.Y != value)
                {
                    StoreCell.Y = value;
                    OnPropertyChanged("ColumnPosition");
                }
            }
        }

        public int Code
        {
            get { return StoreCell.Code; }
            set
            {
                if (StoreCell.Code != value)
                {
                    StoreCell.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public string Name
        {
            get { return StoreCell.Name; }
            set
            {
                if (StoreCell.Name != value)
                {
                    StoreCell.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string ExternalCode
        {
            get { return StoreCell.ExternalCode; }
            set
            {
                if (StoreCell.ExternalCode != value)
                {
                    StoreCell.ExternalCode = value;
                    OnPropertyChanged("ExternalCode");
                }
            }
        }

        public bool Active
        {
            get { return StoreCell.Active; }
            set
            {
                if (StoreCell.Active != value)
                {
                    StoreCell.Active = value;
                    OnPropertyChanged("Active");
                }
            }
        }

        #endregion

        public StoreCellViewModel() { }

        public StoreCellViewModel(int x, int y)
        {
            rowPosition = x;
            columnPosition = y;
        }


    }
}
