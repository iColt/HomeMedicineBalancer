using Csla;
using NHibernate;

namespace HMS_DA.Interfaces
{
    public interface IDomainObjectFactory<T>
    {
		T Create();
		T Create(ICriteria criteria);
		T Update(T obj);
		T Fetch(ICriteria criteria);
		void Delete(ICriteria criteria);
		void Delete(T obj);
	}
}
