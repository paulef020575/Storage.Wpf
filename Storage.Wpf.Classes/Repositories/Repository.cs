using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Wpf.Classes
{
    public class Repository<T> : IRepository<T>

        where T : Entity
    {
        private ISession session;
        public ISession Session
        {
            get
            {
                return session ?? (session = SessionManager.Instance.GetSession());
            }
        }

        public virtual void Create(T t)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Session.Save(t);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();

                    throw e;
                }
            }
        }

        public virtual void Delete(T t)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(t);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        public virtual T Read(int id)
        {
                return Session.Get<T>(id);
        }

        public virtual IQueryable<T> ReadQuery()
        {
                return Session.Query<T>().Where(x => x.IdCompany == 1);
        }

        public virtual IEnumerable<T> ReadList()
        {
                return Session.Query<T>().Where(x => x.IdCompany == 1).ToList<T>();
        }

        public virtual void Update(T t)
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(t);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }
    }
}
