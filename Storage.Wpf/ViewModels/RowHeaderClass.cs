using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.ViewModels.Base;

namespace Storage.Wpf
{
    public class RowHeaderClass : IGridCell
    {
        public int RowPosition { get; private set; }

        public int ColumnPosition => 0;

        public string Title => RowPosition.ToString();

        public RowHeaderClass(int rowPosition)
        {
            RowPosition = rowPosition;
        }
    }
}
