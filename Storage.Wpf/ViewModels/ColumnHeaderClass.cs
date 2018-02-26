using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.ViewModels.Base;
using Storage.Wpf.Classes;

namespace Storage.Wpf
{
    public class ColumnHeaderClass : IGridCell
    {
        public int ColumnPosition { get; private set; }

        public int RowPosition => 0;

        public bool LastColumn { get; private set; } = false;

        public string Title 
        {
            get
            {
                if (LastColumn) return "+";

                string headers = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                return headers.Substring(ColumnPosition, 1);
            }
        }

        public ColumnHeaderClass(int columnPosition)
        {
            ColumnPosition = columnPosition;
        }

        private EventHandler onClick;

        public event EventHandler Click
        {
            add
            {
                LastColumn = true;
                onClick += value;
            }
            remove
            {
                LastColumn = false;
                onClick -= value;
            }

        }

        private StorageCommand clickCommand;

        public StorageCommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                    clickCommand = new StorageCommand(param => onClick(this, EventArgs.Empty), param => LastColumn);

                return clickCommand;
            }
        }

    }
}
