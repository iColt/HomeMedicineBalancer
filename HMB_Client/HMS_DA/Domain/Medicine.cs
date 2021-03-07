using System;
using Csla;
using HMS_DA.Criteria;
using HMS_DA.DomainFactories;

namespace HMB_DA.Domain
{
	[Serializable]
	[Csla.Server.ObjectFactory(typeof(MedicineFactory))]
    public class Medicine : Object<Medicine>
    {

		public static readonly PropertyInfo<DateTime> ValidToProperty = RegisterProperty<DateTime>(new PropertyInfo<DateTime>("ValidTo"));

		public virtual DateTime ValidTo
		{
			get
			{
				return GetProperty<DateTime>(ValidToProperty);
			}
			set
			{
				SetProperty<DateTime>(ValidToProperty, value);
			}
		}


		public static readonly PropertyInfo<int> MedicineTypeIdProperty = RegisterProperty<int>(new PropertyInfo<int>("MedicineTypeId"));
		public virtual int MedicineTypeId
		{
			get
			{
				return GetProperty<int>(MedicineTypeIdProperty);
			}
			set
			{
				SetProperty<int>(MedicineTypeIdProperty, value);
			}
		}

		#region Factory Methods

		public static Medicine New()
		{
			return DataPortal.Create<Medicine>();
		}

		public static Medicine Get(int id)
		{
			return DataPortal.Fetch<Medicine>(new IdCriteria<int>(id));
		}


		#endregion

		public void AsChild()
		{
			base.MarkAsChild();
		}

	}
}
