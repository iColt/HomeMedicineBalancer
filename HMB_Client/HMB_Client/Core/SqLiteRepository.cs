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
		public ISession Session { get; set; }

		#region IRepository members

		public IQueryable<T> CreateQuery()
		{
			return Session.Query<T>();
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
