using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB_Client.Interfaces
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> CreateQuery(ISession session);
		T Save(T entity);
	}
}
