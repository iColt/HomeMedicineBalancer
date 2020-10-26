using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using Domain = HMB_Client.Domain;

namespace HMB_Client.Mappers
{
	public sealed class ObjectMap : ClassMap<Domain.Object>
	{
		public ObjectMap()
		{
			Id(x => x.Id).GeneratedBy.Identity();
			Map(x => x.Code);
			Map(x => x.Name);
		}
	}
}
