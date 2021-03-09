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

        public static readonly PropertyInfo<DateTime> ValidToProperty = RegisterProperty<DateTime>(p => p.ValidTo);

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


        public static readonly PropertyInfo<int> MedicineTypeIdProperty = RegisterProperty<int>(p => p.MedicineTypeId);
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

        //TIP: Navigation property in csla - style. Independent from DAL
        public static readonly PropertyInfo<MedicineType> MedicineTypeProperty = RegisterProperty<MedicineType>(p => p.MedicineType);
        public virtual MedicineType MedicineType
        {
            get
            {
                if (!FieldManager.FieldExists(MedicineTypeProperty)) { 
                    LoadProperty(MedicineTypeProperty, MedicineType.Get(MedicineTypeId));
                }

                return GetProperty<MedicineType>(MedicineTypeProperty);
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

        public override void Delete()
        {
            base.Delete();
            Save();
        }

        #endregion

        public void AsChild()
        {
            base.MarkAsChild();
        }

        protected override void AddBusinessRules()
        {
            // call base class implementation to add data annotation rules to BusinessRules 
            base.AddBusinessRules();

        }

    }
}
