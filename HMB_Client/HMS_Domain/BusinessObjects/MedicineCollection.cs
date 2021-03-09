using Csla;
using HMB_Domain.Criteria;
using System;
using System.Collections.Generic;

namespace HMB_Domain.BusinessObjects
{
    [Serializable]
    [Csla.Server.ObjectFactory("HMS_DA.DomainFactories.MedicineCollectionFactory, HMS_DA")]
    public class MedicineCollection : BusinessListBase<MedicineCollection, Medicine>
    {
        public MedicineCollection() { }

        public static MedicineCollection GetByIds(IEnumerable<int> Ids)
        {
            return DataPortal.Fetch<MedicineCollection>(new CollectionByIdCriteria<IEnumerable<int>, int>(Ids));
        }

        public static MedicineCollection GetAll()
        {
            return DataPortal.Fetch<MedicineCollection>(new object());
        }


        public static MedicineCollection New()
        {
            return DataPortal.Create<MedicineCollection>();
        }
    }
}
