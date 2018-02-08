using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.ViewModels.Base;

namespace Storage.Wpf
{
    public class ColumnHeaderClass : IGridCell
    {
        public int ColumnPosition { get; private set; }

        public int RowPosition => 0;

        public string Title
        {
            get
            {
                string headers = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                return headers.Substring(ColumnPosition, 1);
            }
        }

        public ColumnHeaderClass(int columnPosition)
        {
            ColumnPosition = columnPosition;
        }
    }
}
