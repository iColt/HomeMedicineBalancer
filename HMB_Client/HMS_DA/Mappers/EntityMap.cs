using FluentNHibernate.Mapping;
using HMB_DA.Domain;

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
