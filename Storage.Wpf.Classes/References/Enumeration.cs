using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Enumeration : Entity
    {
        public virtual string Name { get; set; }
        public virtual int ItemIndex { get; set; }
        public virtual string Description { get; set; }

        public Enumeration()
        {
            ItemIndex = 1;
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
