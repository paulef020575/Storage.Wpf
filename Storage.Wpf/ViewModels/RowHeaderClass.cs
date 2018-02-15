using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.ViewModels.Base;
using Storage.Wpf.Classes;

namespace Storage.Wpf
{
    public class RowHeaderClass : IGridCell
    {
        public int RowPosition { get; private set; }

        public int ColumnPosition => 0;

        public bool LastRow { get; private set; } = false;

        public string Title => (LastRow ? "+" : RowPosition.ToString());

        public RowHeaderClass(int rowPosition)
        {
            RowPosition = rowPosition;
        }

        private EventHandler onClick;

        public event EventHandler Click
        {
            add
            {
                LastRow = true;
                onClick += value;
            }
            remove
            {
                LastRow = false;
                onClick -= value;
            }

        }

        private StorageCommand clickCommand;

        public StorageCommand ClickCommand
        {
            get
            {
                if (clickCommand == null)
                    clickCommand = new StorageCommand(param => onClick(this, EventArgs.Empty), param => LastRow);

                return clickCommand;
            }
        }
    }
}
