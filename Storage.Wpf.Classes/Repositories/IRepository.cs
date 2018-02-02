using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public interface IRepository<T> 
        where T : Entity
    {
        IEnumerable<T> ReadList();
        IQueryable<T> ReadQuery();
        T Read(int id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
    }
}
