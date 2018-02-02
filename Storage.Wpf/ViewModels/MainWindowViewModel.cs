using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class MainWindowViewModel : BaseViewModel
    {
        public override string Title => CurrentViewModel.Title;

        private BaseViewModel currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            private set
            {
                currentViewModel = value;

                currentViewModel.PropertyChanged -= ChildTitleModified;
                currentViewModel.PropertyChanged += ChildTitleModified;
                
                currentViewModel.ChangeViewModel = SetCurrentViewModel;
                currentViewModel.OnActivated();

                OnPropertyChanged("CurrentViewModel");
                OnPropertyChanged("Title");
            }
        }

        public MainWindowViewModel()
        {
            CurrentViewModel = new AuthorizationViewModel();
        }

        public void SetCurrentViewModel(BaseViewModel viewModel)
        {
            CurrentViewModel = viewModel;
        }

        private void ChildTitleModified(object sender, EventArgs e)
        {
            OnPropertyChanged("Title");
        }
    }
}
