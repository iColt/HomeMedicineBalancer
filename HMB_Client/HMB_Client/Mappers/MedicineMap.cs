using FluentNHibernate.Mapping;
using HMB_Client.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Mappers
{
	public sealed class MedicineMap : SubclassMap<Medicine>
	{
		public MedicineMap()
		{
			KeyColumn("Id");
			Map(x => x.MedicineTypeId);
			Map(x => x.ValidTo);
		}
	}
}
