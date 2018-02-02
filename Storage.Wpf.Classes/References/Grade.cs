using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Grade : Entity
    {
        #region Properties

        public virtual int Code { get; set; }

        public virtual string ExternalCode { get; set; }

        public virtual string Name { get; set; }

        public virtual bool IsTop { get; set; }

        public virtual IList<Store> StoreGrade { get; protected set; }

        #endregion

        #region Constructor

        public Grade()
        {
            StoreGrade = new List<Classes.Store>();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
