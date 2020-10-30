using HMB_Client.Helpers;
using HMB_Client.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB_Client.Core
{
    public class SqLiteRepository<T> : IRepository<T> where T : class
    {

        protected readonly ISessionFactory sessionFactory;

        public SqLiteRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        #region IRepository members

        //TODO: decorate our repository calls in such form, that i'll have possibility to load iqueryable// public IQueryable<T> CreateQuery()
        public IQueryable<T> CreateQuery(ISession session)
        {
            return session.Query<T>();
        }

        public T GetById(int id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public T Save(T entity)
        {
            using (ISession session = sessionFactory.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    //TODO: Check how SaveOrUpdate works
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }

            return entity;
        }

        public void Delete(T entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                //TODO: Check how SaveOrUpdate works
                session.Delete(entity);
                transaction.Commit();
            }
        }

        #endregion
    }
}
