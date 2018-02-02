using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Header { get; private set; }
        public int Width { get; set; }
        public int Position { get; set; }

        public ColumnAttribute(string header)
        {
            Header = header;
            Width = 0;
            Position = 1000;
        }

        public ColumnAttribute() : this("") { }
    }
}
