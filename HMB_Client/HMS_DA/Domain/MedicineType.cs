using Csla;
using System;

namespace HMB_DA.Domain
{
    [Serializable]
    [Csla.Server.ObjectFactory("HMS_DA.Core.GenericFactory`1[[HMB_DA.Domain.MedicineType, HMB_DA.Domain]], HMB_DA.Domain")]
    public class MedicineType : BusinessBase<MedicineType>
    {

		public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(new PropertyInfo<int>("Id"));
		public virtual int Id
		{
			get
			{
				return GetProperty<int>(IdProperty);
			}
			protected set
			{
				SetProperty<int>(IdProperty, value);
			}
		}

		public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(new PropertyInfo<string>("Name"));
		public virtual string Name
		{
			get
			{
				return GetProperty(NameProperty);
			}
			set
			{
				SetProperty(NameProperty, value);
			}
		}

	

	}
}
