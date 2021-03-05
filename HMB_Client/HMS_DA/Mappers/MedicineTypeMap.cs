using FluentNHibernate.Mapping;
using HMB_DA.Domain;

namespace HMS_DA.Mappers
{
    public sealed class MedicineTypeMap : ClassMap<MedicineType>
	{
		public MedicineTypeMap()
		{
			Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity();
			Map(x => x.Name);
		}
	}
}
