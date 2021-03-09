using Csla;
using HMS_DA.Criteria;
using HMS_DA.DomainFactories;
using System;

namespace HMB_DA.Domain
{
    [Serializable]
    [Csla.Server.ObjectFactory(typeof(MedicineTypeFactory))]
    public class MedicineType : BusinessBase<MedicineType>
    {

        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(p => p.Id);
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

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(p => p.Name);
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

        public void MakeOld()
        {
            MarkOld();
        }

        #region Factory Methods

        public static MedicineType New()
        {
            return DataPortal.Create<MedicineType>();
        }

        public static MedicineType Get(int id)
        {
            return DataPortal.Fetch<MedicineType>(new IdCriteria<int>(id));
        }

        #endregion

    }
}
