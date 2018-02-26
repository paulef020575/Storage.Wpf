using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.Classes;
using Storage.Wpf.ViewModels.Base;

namespace Storage.Wpf
{
    public class StoreCellViewModel : EntityViewModel<StoreCell>, IGridCell
    {
        #region Properties

        public override string Title => (StoreCell == null ? "не размечена" : StoreCell.Name);

        public StoreCell StoreCell => Entity as StoreCell;

        public bool IsCell => (StoreCell != null);

        public bool IsEmpty => (StoreCell == null);

        private int rowPosition;

        public int RowPosition
        {
            get { return (StoreCell == null ? rowPosition + 1 : StoreCell.X + 1); }
            set
            {
                if (StoreCell != null && StoreCell.X != value - 1)
                {
                    StoreCell.X = value - 1;
                    OnPropertyChanged("RowPosition");
                }
            }
        }

        private int columnPosition;

        public int ColumnPosition
        {
            get { return (StoreCell == null ? columnPosition + 1 : StoreCell.Y + 1); }
            set
            {
                if (StoreCell != null && StoreCell.Y != value - 1)
                {
                    StoreCell.Y = value - 1;
                    OnPropertyChanged("ColumnPosition");
                }
            }
        }

        public int[] Position
        {
            get { return new[] {rowPosition, columnPosition}; }
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

        public int RowsCount
        {
            get { return StoreCell.RowsCount; }
            set
            {
                if (StoreCell.RowsCount != value)
                {
                    StoreCell.RowsCount = value;
                    OnPropertyChanged("RowsCount");
                }
            }
        }

        public int ColumnsCount
        {
            get { return StoreCell.ColumnsCount; }
            set
            {
                if (StoreCell.ColumnsCount != value)
                {
                    StoreCell.ColumnsCount = value;
                    OnPropertyChanged("ColumnsCount");
                }
            }
        }

        public bool IsVertical
        {
            get { return StoreCell.IsVertical; }
            set
            {
                if (StoreCell.IsVertical != value)
                {
                    StoreCell.IsVertical = value;
                    OnPropertyChanged("IsVertical");
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

        internal void DeleteCell()
        {
            repository.Delete(StoreCell);
        }
    }
}
