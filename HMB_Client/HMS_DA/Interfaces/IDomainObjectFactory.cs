using NHibernate;

namespace HMB_DA.Interfaces
{
    public interface IDomainObjectFactory<T>
    {
		T Create();
		T Create(ICriteria criteria);
		T Update(T obj);
		T Fetch(object criteria);
		void Delete(T obj);
	}
}
