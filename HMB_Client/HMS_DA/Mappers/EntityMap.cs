using FluentNHibernate.Mapping;
using HMB_Domain.BusinessObjects;

namespace HMB_DA.Mappers
{
	public sealed class EntityMap : SubclassMap<Entity>
	{
		public EntityMap()
		{
			KeyColumn("Id");
			Map(x => x.EntityTypeId);
			Map(x => x.CountryId);
		}
	}
}
