using FluentNHibernate.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Instances;
using System.Diagnostics;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate;
using System.Reflection;

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

    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
                return "Id" + type.Name;

            return "Id" + property.Name; 
        }

        protected string GetKeyName(PropertyInfo property, Type type)
        {
            if (property == null)
                return "ID" + type.Name;  // many-to-many, one-to-many, join

            return "ID" + property.Name; // many-to-one
        }
    }
}