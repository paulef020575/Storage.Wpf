using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;
using Storage.Wpf.Classes.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public static class Database
    {
        public static string ConnectionString;

        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                     Configuration cfg = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
                        .Mappings(m => m.AutoMappings.Add(AutoMap.AssemblyOf<TypeProd>(new AutomappingConfiguration())
                                                            .Conventions.Add<CustomForeignKeyConvention>()
                                                            .Override<Store>(map => map.HasManyToMany<Species>(store => store.StoreSpecies)
                                                                                    .Table("StoreSpecies").ParentKeyColumn("IdStore").ChildKeyColumn("IdSpecies"))
                                                            .Override<Store>(map => map.HasManyToMany<Grade>(store => store.StoreGrade)
                                                                                    .Table("StoreGrade").ParentKeyColumn("IdStore").ChildKeyColumn("IdGrade"))
                                                            .Override<Species>(map => map.HasManyToMany<Store>(species => species.StoreSpecies)
                                                                                    .Table("StoreSpecies").ParentKeyColumn("IdStore").ChildKeyColumn("IdSpecies").Inverse())
                                                            .Override<Grade>(map => map.HasManyToMany<Store>(store => store.StoreGrade)
                                                                                    .Table("StoreGrade").ParentKeyColumn("IdStore").ChildKeyColumn("IdGrade").Inverse())
                           ))
                                                            
                        .BuildConfiguration();

                    sessionFactory = cfg.BuildSessionFactory();
                }

                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

 
    }

    public sealed  class SessionManager
    {
        ISession session;

        public SessionManager()
        {
            session = Database.OpenSession();
        }

        internal ISession GetSession()
        {
            return session;
        }

        public static SessionManager Instance
        {
            get { return Nested.instance; }
        }

        public class Nested
        {
            static Nested() { }

            internal static readonly SessionManager instance = new SessionManager();
        }

        public List<Enumeration> GetEnumeration(string name)
        {
               return session.Query<Enumeration>().Where(x => x.Name == name && x.IdCompany == 1).ToList<Enumeration>();
        }
    }
}
