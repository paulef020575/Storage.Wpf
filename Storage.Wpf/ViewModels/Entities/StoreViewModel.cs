﻿using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.ViewModels.Base;

namespace Storage.Wpf
{
    public class StoreViewModel : EntityViewModel<Store>
    {
        #region Properties

        public override string Title => Name;

        public Store Store => Item as Store;

        [Column("Код", Width = 50)]
        public int Code
        {
            get
            {
                return Store.Code;
            }
            set
            {
                if (Store.Code != value)
                {
                    Store.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        [Column("Код внешней системы")]
        public string ExternalCode
        {
            get { return Store.ExternalCode; }
            set
            {
                if (Store.ExternalCode != value)
                {
                    Store.ExternalCode = value;
                    OnPropertyChanged("ExternalCode");
                }
            }
        }

        [Column("Наименование", Width = 200, Position = 0)]
        public string Name
        {
            get { return Store.Name; }
            set
            {
                if (Store.Name != value)
                {
                    Store.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        [Column("активен")]
        public bool Active
        {
            get { return Store.Active; }
            set
            {
                if (Store.Active != value)
                {
                    Store.Active = value;
                    OnPropertyChanged("Active");
                }
            }
        }

        [Column("Срок хранения", Width = 50)]
        public int MaxDay
        {
            get { return Store.MaxDay; }
            set
            {
                if (Store.MaxDay != value)
                {
                    Store.MaxDay = value;
                    OnPropertyChanged("MaxDay");
                }
            }
        }

        [Column("Учет логистики")]
        public bool Logistic
        {
            get { return Store.Logistic; }
            set
            {
                if (Store.Logistic != value)
                {
                    Store.Logistic = value;
                    OnPropertyChanged("Logistic");
                }
            }
        }

        public int Height
        {
            get { return Store.Height; }
            set
            {
                if (Store.Height != value)
                {
                    Store.Height = value;
                    OnPropertyChanged("Height");
                }
            }
        }

        public int MaxPackageCount
        {
            get { return Store.MaxPackageCount; }
            set
            {
                if (Store.MaxPackageCount != value)
                {
                    Store.MaxPackageCount = value;
                    OnPropertyChanged("MaxPackageCount");
                }
            }
        }

        public decimal Protrusion
        {
            get { return Store.Protrusion; }
            set
            {
                if (Store.Protrusion != value)
                {
                    Store.Protrusion = value;
                    OnPropertyChanged("Protrusion");
                }
            }
        }

        public decimal TotalProtrusion
        {
            get { return Store.TotalProtrusion; }
            set
            {
                if (Store.TotalProtrusion != value)
                {
                    Store.TotalProtrusion = value;
                    OnPropertyChanged("TotalProtrusion");
                }
            }
        }

        public bool Couple
        {
            get { return Store.Couple; }
            set
            {
                if (Store.Couple != value)
                {
                    Store.Couple = value;
                    OnPropertyChanged("Couple");
                }
            }
        }

        private Enumeration type;
        [Column("Тип склада", Position = 1, Width = 200)]
        public Enumeration Type
        {
            get
            {
                if (type == null)
                    type = typeEnumeration.Where(x => x.ItemIndex == Store.Type).First();
                return type;
            }
            set
            {
                if (type != value)
                {
                    type = value;
                    Store.Type = type.ItemIndex;
                    OnPropertyChanged("Type");
                }
            }
        }

        public int WidthFrom
        {
            get
            {
                return Store.WidthFrom;
            }

            set
            {
                if (Store.WidthFrom != value)
                {
                    Store.WidthFrom = value;
                    OnPropertyChanged("WidthFrom");
                }
            }
        }

        public int WidthTo
        {
            get { return Store.WidthTo; }
            set
            {
                if (Store.WidthTo != value)
                {
                    Store.WidthTo = value;
                    OnPropertyChanged("WidthTo");
                }
            }
        }

        public int HeightFrom
        {
            get { return Store.HeightFrom; }
            set
            {
                if (Store.HeightFrom != value)
                {
                    Store.HeightFrom = value;
                    OnPropertyChanged("HeightFrom");
                }
            }
        }

        public int HeightTo
        {
            get { return Store.HeightTo; }
            set
            {
                if (Store.HeightTo != value)
                {
                    Store.HeightTo = value;
                    OnPropertyChanged("HeightTo");
                }
            }
        }
        
        #region TypeEnumeration

        private List<Enumeration> typeEnumeration;

        public List<Enumeration> TypeEnumeration
        {
            get
            {
                if (typeEnumeration == null)
                    typeEnumeration = SessionManager.Instance.GetEnumeration("StoreType");

                return typeEnumeration;
            }
        }

        #endregion

        private EntityIncludedList<Species> speciesList;
        public EntityIncludedList<Species> SpeciesList
        {
            get
            {
                if (speciesList == null)
                {
                    speciesList = new EntityIncludedList<Species>(Store.StoreSpecies);
                    speciesList.PropertyChanged += (e, PropertyChangedEventArgs) => SetAsModified();
                }
                return speciesList;
            }
        }

        private EntityIncludedList<Grade> gradeList;
        public EntityIncludedList<Grade> GradeList
        {
            get
            {
                if (gradeList == null)
                {
                    gradeList = new EntityIncludedList<Grade>(Store.StoreGrade);
                    gradeList.PropertyChanged += (e, PropertyChangedEventArgs) => SetAsModified();
                }

                return gradeList;
            }
           
        }

        private ObservableCollection<IGridCell> cells;
        public ObservableCollection<IGridCell> Cells
        {
            get
            {
                if (cells == null)
                    FillCells(Store);

                return cells;
            }
        }

        private int rowCount;

        public int RowCount
        {
            get { return rowCount + 1; }
            set
            {
                if (rowCount != value - 1)
                {
                    rowCount = value - 1;
                    FillCells(Store);
                }
            }
        }

        private int columnCount;

        public int ColumnCount
        {
            get { return columnCount + 1; }
            set
            {
                if (columnCount != value - 1)
                {
                    columnCount = value - 1;
                    FillCells(Store);
                }
            }

        }

        public string StarColumns
        {
            get
            {
                string s = "1";
                for (int i = 1; i < ColumnCount; i++)
                    s += "," + (i + 1).ToString();

                return s;
            }
        }

        #endregion

        public StoreViewModel() { }

        public StoreViewModel(List<Enumeration> enumeration)
        {
            typeEnumeration = enumeration;
        }


        #region Methods

        protected override void Save()
        {
            SpeciesList.Save(Store.StoreSpecies);
            GradeList.Save(Store.StoreGrade);

            base.Save();

            if (Store.Cells.Count == 0)
            {
                Store.Cells.Add(new Classes.StoreCell()
                {
                    Code = 1,
                    Name = "группа 1",
                    ExternalCode = "01",
                    Store = this.Store,
                    RowsCount = 1,
                    ColumnsCount = 1,
                    Active = true,
                    IsVertical = false,
                    X = 0,
                    Y = 0
                });

                Repository<StoreCell> storeCellRepository = new Repository<StoreCell>();
                storeCellRepository.Create(Store.Cells[0]);
            }
        }

        private void FillCells(Store store)
        {
            if (rowCount == 0) rowCount = Store.Cells.Select(c => c.X).Max() + 1;
            if (columnCount == 0) columnCount = Store.Cells.Select(c => c.Y).Max() + 1;

            cells = new ObservableCollection<IGridCell>();

            for (int x = 0; x < rowCount; x++)
                cells.Add(new RowHeaderClass(x + 1));
            
            for (int y = 0; y < columnCount; y++)
                cells.Add(new ColumnHeaderClass(y + 1));                            

            for (int x = 0; x < rowCount; x++)
                for (int y = 0; y < columnCount; y++)
                {
                    StoreCellViewModel viewModel = new StoreCellViewModel(x, y);
                    StoreCell cell = Store.Cells.Where(c => c.X == x && c.Y == y).FirstOrDefault();
                    viewModel.SetItem(cell);

                    cells.Add(viewModel);
                }

            OnPropertyChanged("RowCount");
            OnPropertyChanged("ColumnCount");
            OnPropertyChanged("Cells");
            OnPropertyChanged("StarColumns");

        }

        private void EditCell(int cellId)
        {
            StoreCellViewModel viewModel = new StoreCellViewModel();
            viewModel.SetItem((new Repository<StoreCell>()).Read(cellId));
            viewModel.LastViewModel = this;
            viewModel.ObjectSaved += StoreCellSaved;
            ChangeViewModel(viewModel);
        }

        private void StoreCellSaved(object sender, EventArgs e)
        {
            StoreCell cell = sender as StoreCell;

            StoreCell cellToReplace = Store.Cells.Where(c => c.Id == cell.Id).FirstOrDefault();
            Store.Cells.Remove(cellToReplace);
            Store.Cells.Add(cell);

            FillCells(Store);
        }

        private void AddCell(int[] position)
        {
            StoreCell cell = new StoreCell()
            {
                Active = true,
                ColumnsCount = 1,
                RowsCount = 1,
                IsVertical = false,
                Name = "Новая группа",
                Store = this.Store,
                X = position[0],
                Y = position[1]
            };

            StoreCellViewModel viewModel = new StoreCellViewModel();
            viewModel.SetItem(cell);
            viewModel.LastViewModel = this;
            viewModel.ObjectSaved += StoreCellSaved;
            ChangeViewModel(viewModel);
        }

        #endregion

        #region Commands

        #region EditCell

        private StorageCommand editCellCommand;

        public StorageCommand EditCellCommand
        {
            get
            {
                if (editCellCommand == null)
                    editCellCommand = new StorageCommand(param => EditCell((int)param));
                return editCellCommand;
            }
        }

        #endregion

        #region AddCell

        private StorageCommand addCellCommand;

        public StorageCommand AddCellCommand
        {
            get
            {
                if (addCellCommand == null)
                    addCellCommand = new StorageCommand(param => AddCell((int[])param));
                return addCellCommand;
            }
        }

        #endregion

        #endregion
    }
}
