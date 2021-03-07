using Csla;
using HMB_DA.Domain;
using HMS_DA.Criteria;
using HMS_DA.DomainFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_DA.Domain
{
    [Serializable]
    [Csla.Server.ObjectFactory(typeof(MedicineTypeCollectionFactory))]
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

        internal static MedicineTypeCollection New()
        {
            return DataPortal.Create<MedicineTypeCollection>();
        }
    }
}
