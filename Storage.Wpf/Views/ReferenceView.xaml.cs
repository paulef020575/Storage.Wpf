﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Storage.Wpf
{
    /// <summary>
    /// Логика взаимодействия для ReferenceView.xaml
    /// </summary>
    public partial class ReferenceView : UserControl
    {
        Dictionary<DataGridColumn, int> columnsPosition = new Dictionary<DataGridColumn, int>();

        private class ColumnPosition
        {
            public DataGridColumn Column { get; set; }
            public int Position { get; set; }
        }

        public ReferenceView()
        {
            InitializeComponent();
            dgList.Columns.Clear();
        }

        private void dgList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            List<ColumnPosition> columnPositionList = new List<Wpf.ReferenceView.ColumnPosition>();

            foreach (DataGridColumn column in columnsPosition.Keys)
                columnPositionList.Add(new ColumnPosition()
                {
                    Column = column,
                    Position = columnsPosition[column]
                });

            var list = columnPositionList.OrderBy(x => x.Position);
            int position = 0;
            foreach (ColumnPosition item in list)
                item.Column.DisplayIndex = position++;
        }

        private void dgList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            var attr = propertyDescriptor.Attributes[typeof(ColumnAttribute)] as ColumnAttribute;
            if (attr != null)
            {
                DataGridColumn column;

                if (e.PropertyType == typeof(bool))
                    column = new DataGridCheckBoxColumn()
                    {
                        Binding = new Binding(e.PropertyName),
                        Header = (attr.Header.Length > 0 ? attr.Header : e.PropertyName),
                        Width = (attr.Width > 0 ? attr.Width : 25)
                    };
                else
                    column = new DataGridTextColumn()
                    {
                        Binding = new Binding(e.PropertyName),
                        Header = (attr.Header.Length > 0 ? attr.Header : e.PropertyName),
                        Width = (attr.Width > 0 ? attr.Width : 100)
                    };

                columnsPosition.Add(column, attr.Position);
                e.Column = column;
            }
            else
                e.Cancel = true;
        }
    }
}
