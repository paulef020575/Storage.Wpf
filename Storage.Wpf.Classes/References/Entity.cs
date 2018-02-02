using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Entity 
    {
        public virtual int Id { get; set; }
        public virtual int IdCompany { get; set; } 

        public Entity() { IdCompany = 1; }

        public override bool Equals(object obj)
        {
            Entity other = obj as Entity;

            if (other != null)
                return (Id == other.Id);

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
