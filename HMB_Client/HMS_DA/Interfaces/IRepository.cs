using NHibernate;
using System.Linq;

namespace HMB_DA.Interfaces
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> CreateQuery(ISession session);

		T GetById(int id);

		T Save(T entity);

		void Delete(T entity);
	}
}
