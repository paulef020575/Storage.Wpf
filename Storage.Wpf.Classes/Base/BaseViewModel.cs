using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        [Browsable(false)]
        public abstract string Title { get; }


        public bool IsModified
        {
            get;
            private set;
        }

        public Action<BaseViewModel> ChangeViewModel { get; set; }

        public BaseViewModel LastViewModel { get; set; }

        #region NotifyPropertyChanged implementation

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

            if (propertyName != "IsModified")
                SetAsModified();
        }

        #endregion
        
        #region Methods

        public void SetAsModified()
        {
            IsModified = true;
            OnPropertyChanged("IsModified");
        }

        public void ClearModifiedState()
        {
            IsModified = false;
            OnPropertyChanged("IsModified");
        }

        protected virtual void CloseViewModel()
        {
            if (LastViewModel != null)
                ChangeViewModel(LastViewModel);
        }

        public virtual void OnActivated() { }


        #endregion
    }
}
