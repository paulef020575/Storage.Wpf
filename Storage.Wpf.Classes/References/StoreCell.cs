using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class StoreCell : Entity
    {
        #region Properties

        public virtual int Code { get; set; }
        public virtual string ExternalCode { get; set; }
        public virtual Store Store { get; set; }
        public virtual int RowsCount { get; set; }
        public virtual int ColumnsCount { get; set; }
        public virtual bool Active { get; set; }
        public virtual bool IsVertical { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        #region Дороги

        public virtual Road RoadLeft { get; set; }
        public virtual Road RoadRight { get; set; }
        public virtual Road RoadTop { get; set; }
        public virtual Road RoadBot { get; set; }

        #endregion

        #endregion
    }
}
