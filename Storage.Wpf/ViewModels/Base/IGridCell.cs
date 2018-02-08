using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.ViewModels.Base
{
    public interface IGridCell
    {
        int RowPosition { get; }

        int ColumnPosition { get; }
    }
}
