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
			Session.Save(entity);

			return entity;
		}

		#endregion
	}
}
