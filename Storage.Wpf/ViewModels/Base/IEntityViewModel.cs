using Storage.Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf
{
    public interface IEntityViewModel
    {
        Entity Item { get; }
        void SetItem(Entity item);
        void SetItemForEdit(Entity item);
    }
}
