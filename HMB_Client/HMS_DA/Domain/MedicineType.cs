using Csla;
using HMS_DA.DomainFactories;
using System;

namespace HMB_DA.Domain
{
    [Serializable]
    [Csla.Server.ObjectFactory(typeof(MedicineTypeFactory))]
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

		public void AsChild()
        {
			base.MarkAsChild();
        }

	}
}
