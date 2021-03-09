using Csla;
using HMB_Domain.Criteria;
using System;
using System.Collections.Generic;

namespace HMB_Domain.BusinessObjects
{
    [Serializable]
    [Csla.Server.ObjectFactory("HMB_DA.DomainFactories.MedicineTypeCollectionFactory, HMB_DA")]
    public class MedicineTypeCollection : BusinessListBase<MedicineTypeCollection, MedicineType>
    {

        public MedicineTypeCollection() { }

        public static MedicineTypeCollection GetByIds(IEnumerable<int> Ids)
        {
            return DataPortal.Fetch<MedicineTypeCollection>(new CollectionByIdCriteria<IEnumerable<int>, int>(Ids));
        }

        public static MedicineTypeCollection GetAll()
        {
            return DataPortal.Fetch<MedicineTypeCollection>(new object());
        }

        public static MedicineTypeCollection New()
        {
            return DataPortal.Create<MedicineTypeCollection>();
        }
    }
}
