using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.Classes;

namespace Storage.Wpf.ViewModels.Entities
{
    public class StoreCellViewModel : EntityViewModel<StoreCell>
    {
        #region Properties

        public override string Title => (StoreCell == null ? "не размечена" : StoreCell.Name);

        public StoreCell StoreCell => Entity as StoreCell;

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

        #endregion

        public StoreCellViewModel() { }

        public StoreCellViewModel(int x, int y)
        {
            rowPosition = x;
            columnPosition = y;
        }


    }
}
