using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Storage.Wpf
{
    public class ReferenceViewModel<U, V> : BaseViewModel
       where U : Entity, new()
       where V : EntityViewModel<U>, new()
    {
        #region Properties

        protected Repository<U> Repository { get; private set; }

        public ObservableCollection<V> List { get; private set; }

        public Type ItemType { get { return typeof(V); } }

        public override string Title => "Справочник";

        private string s;
        public string S
        {
            get { return s; }
            set
            {
                s = value;
                OnPropertyChanged("S");
            }
        }

        private V selectedItem;
        public V SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public bool HasSelectedItem { get { return (SelectedItem != null); } }

        #endregion

        public ReferenceViewModel()
        {
            Repository = new Repository<U>();
            S = DateTime.Now.ToLongTimeString();
        }


        #region Methods

        public override void OnActivated()
        {
            GetList();
        }

        protected virtual void GetList()
        {
            ObservableCollection<V> list = new ObservableCollection<V>();
            IEnumerable<U> itemList = Repository.ReadList();
            foreach (U item in itemList)
            {
                V viewModel = CreateItemViewModel();
                viewModel.SetItem(item);
                list.Add(viewModel);
            }

            List = list;
            OnPropertyChanged("List");
        }

        protected virtual V CreateItemViewModel()
        {
            return new V();
        }

        protected virtual void Add()
        {
            V itemViewModel = new V();
            itemViewModel.LastViewModel = this;
            ChangeViewModel(itemViewModel);
        }

        protected virtual void EditSelectedItem()
        {
            V view = new V();
            U item = Repository.Read(SelectedItem.Item.Id);
            view.SetItemForEdit(item);
            view.LastViewModel = this;
            ChangeViewModel(view);
        }

        protected virtual void DeleteSelectedItem()
        {
            //if (System.Windows.MessageBox.Show("Удалить объект?", SelectedItem.Title, System.Windows.MessageBoxButton.YesNo)
            //    == System.Windows.MessageBoxResult.Yes)
            //{
            //    V view = SelectedItem;
            //    List.Remove(view);

            //    Repository.Delete((U)view.Item);
            //}

            QuestionViewModel questionViewModel = QuestionViewModel.ConfirmDeletion(SelectedItem.Title);
            questionViewModel.YesChoosed += (sender, e) => Remove(SelectedItem);
            questionViewModel.NoChoosed += (sender, e) => ChangeViewModel(this);
            ChangeViewModel(questionViewModel);
        }

        private void Remove(V item)
        {
            List.Remove(item);
            Repository.Delete((U)item.Item);
            ChangeViewModel(this);
        }


        #endregion

        #region Commands

        #region AddCommand

        private StorageCommand addCommand;

        public StorageCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new StorageCommand(param => Add());
                return addCommand;
            }
        }

        #endregion

        #region EditCommand

        private StorageCommand editCommand;

        public StorageCommand EditCommand
        {
            get
            {
                if (editCommand == null)
                    editCommand = new StorageCommand(param => EditSelectedItem(), param => HasSelectedItem);

                return editCommand;
            }
        }

        #endregion

        #region DeleteCommand

        private StorageCommand deleteCommand;

        public StorageCommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                    deleteCommand = new StorageCommand(param => DeleteSelectedItem(), param => HasSelectedItem);

                return deleteCommand;
            }
        }

        #endregion

        #region RefreshCommand

        private StorageCommand refreshCommand;

        public StorageCommand RefreshCommand
        {
            get
            {
                if (refreshCommand == null)
                    refreshCommand = new StorageCommand(param => GetList());

                return refreshCommand;
            }
        }

        #endregion

        #endregion
    }
}
