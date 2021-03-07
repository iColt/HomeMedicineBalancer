using CommonServiceLocator;
using Csla.Reflection;
using Csla.Server;
using HMS_DA.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_DA.Core
{
    public abstract class AbstractNHibernateCollectionFactory<T> : ObjectFactory, IDomainObjectFactory<T>
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

		public virtual T Update(T obj)
		{
			return obj;
		}

		public virtual T Fetch(object criteria)
		{
			throw new NotImplementedException("Fetch method is not implemented for " + typeof(T));
		}


		public virtual void Delete(ICriteria criteria)
		{
			throw new NotImplementedException("Delete with criteria method is not implemented for " + typeof(T));
		}

		public virtual void Delete(T obj)
		{
			throw new NotImplementedException("Delete method is not implemented for " + typeof(T));
		}

	}
}
