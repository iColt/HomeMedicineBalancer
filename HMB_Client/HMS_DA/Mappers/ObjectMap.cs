﻿using FluentNHibernate.Mapping;
using Domain = HMB_DA.Domain;

namespace HMB_DA.Mappers
{
	public sealed class ObjectMap : ClassMap<Domain.Object>
	{
		public ObjectMap()
		{
			Id(x => x.Id).GeneratedBy.Identity();
			Map(x => x.Code);
			Map(x => x.Name);
			Map(x => x.CreatedDate);
		}
	}
}