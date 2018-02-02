using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class AuthorizationViewModel : BaseViewModel
    {
        #region Properties

        public override string Title => "Авторизация";

        public string UserName { get; set; }

        public string Password { get; set; }

        #endregion

        #region Methods

        private void Close()
        {
            Environment.Exit(0);
        }

        private void Authorize()
        {
            ChangeViewModel(new WorkspaceViewModel());
        }

        #endregion

        #region Commands

        #region Close

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

        #region AuthorizeCommand

        private StorageCommand authorizeCommand;

        public StorageCommand AuthorizeCommand
        {
            get
            {
                if (authorizeCommand == null)
                    authorizeCommand = new StorageCommand(param => Authorize());

                return authorizeCommand;
            }
        }

        #endregion

        #endregion
    }
}
