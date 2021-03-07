using System;
using Csla;

namespace HMB_DA.Domain
{
    [Serializable]
    public abstract class Object<T> : BusinessBase<T> where T : Object<T>
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


		public static readonly PropertyInfo<string> CodeProperty = RegisterProperty<string>(new PropertyInfo<string>("Code"));
		public virtual string Code
		{
			get
			{
				return GetProperty(CodeProperty);
			}
			set
			{
				SetProperty(CodeProperty, value);
			}
		}

		public static readonly PropertyInfo<DateTime> CreatedDateProperty = RegisterProperty<DateTime>(new PropertyInfo<DateTime>("CreatedDate"));

		public virtual DateTime CreatedDate
		{
			get
			{
				return GetProperty<DateTime>(CreatedDateProperty);
			}
			set
			{
				SetProperty<DateTime>(CreatedDateProperty, value);
			}
		}

		public void MakeOld()
        {
			MarkOld();
        }

	}
}
