using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Species : Entity
    {
        #region Properties

        public virtual int Code { get; set; }

        public virtual string ExternalCode { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Store> StoreSpecies { get; protected set; }

        #endregion

        #region Constructor

        public Species()
        {
            StoreSpecies = new List<Store>();
        }

        #endregion

        public override string ToString()
        {
            return Name;
        }
    }
}
