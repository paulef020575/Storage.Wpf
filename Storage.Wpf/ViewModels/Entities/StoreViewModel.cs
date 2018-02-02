﻿using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        public StoreViewModel() { }

        public StoreViewModel(List<Enumeration> enumeration)
        {
            typeEnumeration = enumeration;
        }


        protected override void Save()
        {
            foreach (var item in SpeciesList)
            {
                if (item.IsIncluded && !Store.StoreSpecies.Contains(item.Entity))
                {
                    Store.StoreSpecies.Add(item.Entity);
                    item.Entity.StoreSpecies.Add(Store);
                }

                if (!item.IsIncluded && Store.StoreSpecies.Contains(item.Entity))
                {
                    Store.StoreSpecies.Remove(item.Entity);
                    item.Entity.StoreSpecies.Remove(Store);
                }
            }
            base.Save();
        }
    }
}