using FluentNHibernate.Mapping;
using HMB_Domain.BusinessObjects;

namespace HMB_DA.Mappers
{
	public sealed class MedicineMap : SubclassMap<Medicine>
	{
		public MedicineMap()
		{
			Not.LazyLoad();
			KeyColumn("Id");
			Map(x => x.MedicineTypeId);
			Map(x => x.ValidTo);
		}
	}
}
