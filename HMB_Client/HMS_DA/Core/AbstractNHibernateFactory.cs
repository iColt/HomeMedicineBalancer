using CommonServiceLocator;
using Csla;
using Csla.Reflection;
using HMS_DA.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_DA.Core
{
    public abstract class AbstractNHibernateFactory<T> : IDomainObjectFactory<T> where T : BusinessBase<T>
    {

        protected static NHibernate.ISession Session
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ISessionFactory>().OpenSession();
            }
        }

        public virtual T Create()
        {
            return (T)MethodCaller.CreateInstance(typeof(T));
        }

        public virtual T Create(ICriteria criteria)
        {
            return Create();
        }

        public void Delete(T obj)
        {
            Session.Delete(obj);
        }

        public void Delete(ICriteria criteria)
        {
            Session.Flush();
            Delete(Fetch(criteria));
        }

        public T Update(T obj)
        {
            if (obj.IsNew)
            {
                Session.Save(obj);
            }
            else
            {
                Session.Update(obj);
            }
            return obj;
        }

        public virtual T Fetch(ICriteria criteria)
        {
            throw new NotImplementedException("Fetch method is not implemented for " + typeof(T));
        }

    }
}
