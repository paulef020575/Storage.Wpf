using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class QuestionViewModel : BaseViewModel
    {

        public override string Title { get; }
        public string Question { get; private set; }

        public static int YesButton => 1;
        public static int NoButton => 2;
        public static int CancelButton => 4;

        public int Buttons { get; private set; }

        public bool ShowYesButton => ((Buttons & QuestionViewModel.YesButton) > 0);
        public bool ShowNoButton => ((Buttons & QuestionViewModel.NoButton) > 0);
        public bool ShowCancelButton => ((Buttons & QuestionViewModel.CancelButton) > 0);

        public int ButtonCount
            => (ShowYesButton ? 1 : 0) + (ShowNoButton ? 1 : 0) + (ShowCancelButton ? 1 : 0);

        public QuestionViewModel(string title, string question)
        {
            Title = title;
            Question = question;
            Buttons = QuestionViewModel.YesButton | QuestionViewModel.NoButton | QuestionViewModel.CancelButton;
        }

        public static QuestionViewModel ConfirmClosingWithChanges(string title)
        {
            return new QuestionViewModel(title, ConfirmClosingWithChangesQuestion);
        }

        public static QuestionViewModel ConfirmExit()
        {
            return new Wpf.QuestionViewModel("Выход", ConfirmExitQuestion)
            {
                Buttons = YesButton | NoButton
            };
        }

        #region Choosing events

        private EventHandler onYesChoosed;
        public event EventHandler YesChoosed
        {
            add { onYesChoosed += value; }
            remove { onYesChoosed -= value; }
        }

        private EventHandler onNoChoosed;
        public event EventHandler NoChoosed
        {
            add { onNoChoosed += value; }
            remove { onNoChoosed -= value; }
        }

        private EventHandler onCancelChoosed;
        public event EventHandler CancelChoosed
        {
            add { onCancelChoosed += value; }
            remove { onCancelChoosed -= value; }
        }

        #endregion

        #region Commands

        #region YesCommand

        private StorageCommand yesCommand;
        public StorageCommand YesCommand
        {
            get
            {
                if (yesCommand == null)
                    yesCommand = new StorageCommand(param => { if (onYesChoosed != null) onYesChoosed(this, EventArgs.Empty); });
                return yesCommand;
            }
        }

        #endregion

        #region NoCommand

        private StorageCommand noCommand;
        public StorageCommand NoCommand
        {
            get
            {
                if (noCommand == null)
                    noCommand = new StorageCommand(param => { if (onNoChoosed != null) onNoChoosed(this, EventArgs.Empty); });
                return noCommand;
            }
        }

        #endregion

        #region CancelCommand

        private StorageCommand cancelCommand;
        public StorageCommand CancelCommand
        {
            get
            {
                if (cancelCommand == null)
                    cancelCommand = new StorageCommand(param => { if (onCancelChoosed != null) onCancelChoosed(this, EventArgs.Empty); });
                return cancelCommand;
            }
        }

        #endregion

        #endregion

        #region Questions

        public static string ConfirmClosingWithChangesQuestion
            => "В запись были внесены изменения. Сохранить их?";

        public static string ConfirmExitQuestion => "Закрыть программу?";
        
        #endregion
    }
}
