using Csla;
using HMB_DA.Domain;
using HMS_DA.Criteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_DA.Domain
{
    [Serializable]
    [Csla.Server.ObjectFactory("HMS_DA.Core.GenericFactory`1[[HMB_DA.Domain.MedicineTypeCollection, HMB_DA]], HMB_DA")]
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
