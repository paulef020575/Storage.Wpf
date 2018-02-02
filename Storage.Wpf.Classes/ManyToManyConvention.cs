using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Instances;
using System.Diagnostics;
using FluentNHibernate.Conventions.Inspections;

namespace Storage.Wpf.Classes.Conventions
{
    //public class ManyToManyConvention : IHasManyToManyConvention
    //{
    //    public void Apply(IManyToManyCollectionInstance instance)
    //    {
    //        Debug.Assert(instance.OtherSide != null);
    //        if (((IManyToManyCollectionInspector)instance.OtherSide).Inverse)
    //        {
    //            instance.Table(string.Format("{0}{1}",
    //                            instance.EntityType.Name,
    //                            instance.EntityType.Name));
    //        }
    //        else
    //        {
    //            instance.Inverse();
    //        }

    //        instance.Cascade.All();
    //    }
    //}

    public class MyManyToManyTableNameConvention : ManyToManyTableNameConvention
    {
        protected override string GetBiDirectionalTableName(IManyToManyCollectionInspector collection, IManyToManyCollectionInspector otherSide)
        {
            return collection.EntityType.Name + otherSide.EntityType.Name;
        }

        protected override string GetUniDirectionalTableName(IManyToManyCollectionInspector collection)
        {
            return collection.EntityType.Name + collection.ChildType.Name;
        }
    }

}