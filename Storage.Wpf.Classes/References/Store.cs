using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Store : Entity
    {
        public virtual int Code { get; set; }
        public virtual string ExternalCode { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Active { get; set; }
        public virtual int MaxDay { get; set; }
        public virtual bool Logistic { get; set; }
        public virtual int Height { get; set; }
        public virtual int MaxPackageCount { get; set; }
        public virtual decimal Protrusion { get; set; }
        public virtual decimal TotalProtrusion { get; set; }
        public virtual bool Couple { get; set; }
        public virtual int Type { get; set; }

        public virtual int WidthFrom { get; set; }
        public virtual int WidthTo { get; set; }
        public virtual int HeightFrom { get; set; }
        public virtual int HeightTo { get; set; }

        public virtual IList<Species> StoreSpecies { get; protected set; }

        public Store()
        {
            Type = 1;

            HeightFrom = WidthFrom = 0;
            HeightTo = WidthTo = 1000;

            MaxDay = 90;
            MaxPackageCount = 3;

            StoreSpecies = new List<Species>();
        }
    }
}
