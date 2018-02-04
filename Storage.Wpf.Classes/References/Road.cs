using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Road : Entity
    {
        #region Properties

        public virtual string Code { get; set; }
        public virtual bool Blocked { get; set; }

        #endregion
    }
}
