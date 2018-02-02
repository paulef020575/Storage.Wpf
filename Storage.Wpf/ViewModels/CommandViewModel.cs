using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public class CommandViewModel : BaseViewModel
    {
        public override string Title
        {
            get;
        }

        public StorageCommand Command { get; }

        public bool NotSeparator { get; }

        public bool IsCommandGroup { get; }

        public List<CommandViewModel> Subitems { get; }

        public CommandViewModel(string title, Action<object> execute)
        {
            Title = title;
            Command = new StorageCommand(execute);
            NotSeparator = true;
            IsCommandGroup = false;
        }

        public CommandViewModel(string title)
        {
            Title = title;
            NotSeparator = false;
            IsCommandGroup = true;
            Subitems = new List<CommandViewModel>();
        }

        public CommandViewModel()
        {
            Title = "";
            NotSeparator = false;
            IsCommandGroup = false;
        }


        public static CommandViewModel Separator()
        {
            return new Wpf.CommandViewModel();
        }

        public void Add(CommandViewModel subitem)
        {
            Subitems.Add(subitem);
        }

        public void Add(string title, Action<object> execute)
        {
            Add(new CommandViewModel(title, execute));
        }
    }
}
