using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Nomenclature : Entity
    {
        #region Properties

        public virtual int Code { get; set; }
        public virtual string ExternalCode { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Active { get; set; }
        public virtual Species Species { get; set; }
        public virtual TypeProd TypeProd { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual int Request { get; set; }
        public virtual int Wethness { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        #endregion

        public Nomenclature() { Name = ""; }

        public override string ToString()
        {
            if (Species != null && TypeProd != null && Grade != null)
                return Species.ToString() + " / " 
                    + TypeProd.ToString() + " / " 
                    + Grade.ToString() + " " 
                    + Height.ToString() + "x" + Width.ToString();

            return "Новая номенклатура";
        }
    }
}
