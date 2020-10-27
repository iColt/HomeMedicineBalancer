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
        #region IRepository members

        //TODO: decorate our repository calls in such form, that i'll have possibility to load iqueryable// public IQueryable<T> CreateQuery()
        public IQueryable<T> CreateQuery(ISession session)
        {
            return session.Query<T>();
        }

        public T Save(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);
                transaction.Commit();
            }

            return entity;
        }

        #endregion
    }
}
