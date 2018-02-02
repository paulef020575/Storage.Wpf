using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class EntityIncludedList<T> : List<EntityIncluded<T>>
        where T : Entity
    {
        #region Constructor

        private EntityIncludedList() : base() { }


        public EntityIncludedList(IList<T> includedItemList)
            : this()
        {
            Repository<T> repository = new Repository<T>();
            IEnumerable<T> itemList = repository.ReadList();

            foreach (T item in itemList)
            {
                Add(new EntityIncluded<T>(item, includedItemList.Contains(item)));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                foreach (EntityIncluded<T> item in this)
                    item.PropertyChanged += value;
            }

            remove
            {
                foreach (EntityIncluded<T> item in this)
                    item.PropertyChanged -= value;
            }
        }


        public void Save(IList<T> itemList)
        {
            foreach (EntityIncluded<T> item in this)
            {
                if (item.IsIncluded && !itemList.Contains(item.Entity))
                    itemList.Add(item.Entity);

                if (!item.IsIncluded && itemList.Contains(item.Entity))
                    itemList.Remove(item.Entity);
            }
        }
    }


}
