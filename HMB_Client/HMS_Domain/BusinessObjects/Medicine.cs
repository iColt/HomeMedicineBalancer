using System;
using Csla;
using HMB_Domain.Criteria;

namespace HMB_Domain.BusinessObjects
{
    [Serializable]
    //TIP: assembly qualified name of factory
    [Csla.Server.ObjectFactory("HMB_DA.DomainFactories.MedicineFactory, HMB_DA")]
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
