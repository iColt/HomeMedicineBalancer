using System;
using Csla;
using HMS_DA.Criteria;

namespace HMB_DA.Domain
{
	[Serializable]
	[Csla.Server.ObjectFactory("HMS_DA.Core.GenericFactory`1[[HMB_DA.Domain.Medicine, HMB_DA.Domain]], HMB_DA.Domain")]
    public class Medicine : Object<Medicine>
    {

		public static readonly PropertyInfo<DateTime> ValidToProperty = RegisterProperty<DateTime>(new PropertyInfo<DateTime>("ValidTo"));

		public DateTime ValidTo
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

	}
}
