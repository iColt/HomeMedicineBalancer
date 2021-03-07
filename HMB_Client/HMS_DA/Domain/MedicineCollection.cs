using Csla;
using HMB_DA.Domain;
using HMS_DA.Criteria;
using HMS_DA.DomainFactories;
using System;
using System.Collections.Generic;

namespace HMS_DA.Domain
{
    [Serializable]
    [Csla.Server.ObjectFactory(typeof(MedicineCollectionFactory))]
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


        internal static MedicineCollection New()
        {
            return DataPortal.Create<MedicineCollection>();
        }
    }
}
