using FluentNHibernate.Mapping;
using Domain = HMB_DA.Domain;

namespace HMB_DA.Mappers
{
	public sealed class ObjectMap<T> : ClassMap<Domain.Object<T>> where T : Domain.Object<T>
	{
		public ObjectMap()
		{
			//TIP: define table for generic NHibernate mapper( in other case, if we, for example, tried to load from db Medicine subclass object
			//NHibernate would create query to Object_Medicine table)
			Table("Object");
			//TIP: NHibernate requires all props. of object, configured for lazy - load
			Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity();
			Map(x => x.Code);
			Map(x => x.Name);
			Map(x => x.CreatedDate);
		}
	}
}
