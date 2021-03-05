using Csla;
using HMB_DA.Domain;
using HMS_DA.Criteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_DA.Domain
{
    [Serializable]
    [Csla.Server.ObjectFactory("HMS_DA.Core.GenericFactory`1[[HMB_DA.Domain.MedicineCollection, HMB_DA.Domain]], HMB_DA.Domain")]
    public class MedicineCollection : BusinessListBase<MedicineCollection, Medicine>
    {
        public MedicineCollection() { }

        public static MedicineCollection GetByIds(IEnumerable<int> Ids)
        {
            return DataPortal.Fetch<MedicineCollection>(new CollectionByIdCriteria<IEnumerable<int>, int>(Ids));
        }

        internal static MedicineCollection New()
        {
            return DataPortal.Create<MedicineCollection>();
        }
    }
}
