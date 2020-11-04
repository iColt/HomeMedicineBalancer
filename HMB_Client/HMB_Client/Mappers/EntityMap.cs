using FluentNHibernate.Mapping;
using HMB_Client.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Mappers
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
