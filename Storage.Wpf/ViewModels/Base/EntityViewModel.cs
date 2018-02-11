using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Wpf.Classes;

namespace Storage.Wpf
{
    public abstract class EntityViewModel<T> : BaseViewModel, IEntityViewModel
        where T : Entity, new()
    {
        #region Properties

        public override string Title => Entity.ToString();

        private T entity;

        protected virtual T Entity
        {
            get { return entity; }
            set
            {
                entity = value;
                GetAdvancedData();
            }
        }

        public Entity Item
        {
            get { return Entity as Entity; }
        }

        protected Repository<T> repository;

        #endregion

        #region Constructors

        public EntityViewModel(T entity)
        {
            repository = new Repository<T>();
            SetItem(entity);
        }

        public EntityViewModel()
            : this(new T())
        { }

        #endregion

        #region Methods

        public virtual void SetItem(Entity item)
        {
            Entity = (T)item;
        }

        public virtual void SetItemForEdit(Entity item)
        {
            Entity = (T)item;
        }

        protected virtual void Save()
        {
            repository.Update(Entity);
            OnObjectSaved();
            ClearModifiedState();
        }

        protected virtual void SaveAndClose()
        {
            Save();
            CloseViewModel();
        }



        protected virtual void Close()
        {
            if (IsModified)
            {
                QuestionViewModel questionViewModel = QuestionViewModel.ConfirmClosingWithChanges(Title);
                questionViewModel.YesChoosed += (sender, e) => { Save(); CloseViewModel(); };
                questionViewModel.NoChoosed += (sender, e) => { CloseViewModel(); };
                questionViewModel.CancelChoosed += (sender, e) => { ChangeViewModel(this); };
                ChangeViewModel(questionViewModel);
            }
            else
                CloseViewModel();
        }

        protected virtual void GetAdvancedData()
        {
        }


        public override string ToString()
        {
            return Title;
        }

        #endregion

        #region Commands

        #region SaveCommand

        private StorageCommand saveCommand;

        public StorageCommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new StorageCommand(param => Save(), param => IsModified);

                return saveCommand;
            }
        }

        #endregion
        
        #region OkCommand

        private StorageCommand okCommand;

        public StorageCommand OkCommand
        {
            get
            {
                if (okCommand == null)
                    okCommand = new StorageCommand(param => SaveAndClose(), param => IsModified);
                return okCommand;
            }
        }

        #endregion

        #region CloseCommand

        private StorageCommand closeCommand;

        public StorageCommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new StorageCommand(param => Close());
                return closeCommand;
            }
        }

        #endregion

        #endregion

        #region Event handlers

        #region Object saved

        private EventHandler onObjectSaved;

        public event EventHandler ObjectSaved
        {
            add { onObjectSaved += value; }
            remove { onObjectSaved -= value; }
        }

        protected virtual void OnObjectSaved()
        {
            if (onObjectSaved != null)
                onObjectSaved(Item, EventArgs.Empty);
        }


        #endregion

        #endregion
    }
}
