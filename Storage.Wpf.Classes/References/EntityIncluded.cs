using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class EntityIncluded<T> : INotifyPropertyChanged
        where T : Entity
    {
        #region Properties

        public T Entity { get; private set; }

        private bool isIncluded;

        public bool IsIncluded
        {
            get { return isIncluded; }
            set
            {
                if (isIncluded != value)
                {
                    isIncluded = value;
                    OnPropertyChanged("IsIncluded");
                }
            }
        }

        #endregion

        #region Constructor

        private EntityIncluded() { }

        public EntityIncluded(T entity, bool _isIncluded)
        {
            Entity = entity;
            isIncluded = _isIncluded;
        }

        #endregion

        #region INotifyPropertyChanged implementation

        private PropertyChangedEventHandler onPropertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add { onPropertyChanged += value; }
            remove { onPropertyChanged -= value; }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (onPropertyChanged != null)
                onPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
