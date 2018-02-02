using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class WorkspaceViewModel : BaseViewModel
    {
        #region Properties

        public override string Title => Workspace.Title;

        public ObservableCollection<CommandViewModel> CommandList { get; private set; }

        private BaseViewModel workspace;
        public BaseViewModel Workspace
        {
            get { return workspace; }
            private set
            {
                workspace = value;
                value.ChangeViewModel = ChangeWorkspace;
                value.OnActivated();
                OnPropertyChanged("Workspace");
            }
        }


        #endregion

        public WorkspaceViewModel()
        {
            CreateCommandList();

            Workspace = new RefStoreViewModel();
        }

        private void CreateCommandList()
        {
            CommandList = new ObservableCollection<CommandViewModel>();

            CommandViewModel references = new CommandViewModel("Справочники");
            references.Add("Виды продукции", param => { ChangeWorkspace(new RefTypeProdViewModel()); });
            references.Add("Породы", param => { ChangeWorkspace(new RefSpeciesViewModel()); });
            references.Add("Сорта", param => { ChangeWorkspace(new RefGradeViewModel()); });
            references.Add("Склады", param => { ChangeWorkspace(new RefStoreViewModel()); });
            references.Add("Номенклатура", param => { ChangeWorkspace(new RefNomenclatureViewModel()); });

            CommandList.Add(references);
            CommandList.Add(new CommandViewModel("Выход", param => Exit()));
        }

        private void Exit()
        {
            BaseViewModel currentViewModel = Workspace;

            QuestionViewModel questionViewModel = QuestionViewModel.ConfirmExit();
            questionViewModel.YesChoosed += (sender, e) => { Environment.Exit(1); };
            questionViewModel.NoChoosed += (sender, e) => { ChangeWorkspace(currentViewModel); };

            ChangeWorkspace(questionViewModel);
        }

        private void ChangeWorkspace(BaseViewModel obj)
        {
            Workspace = obj;
        }


    }
}
