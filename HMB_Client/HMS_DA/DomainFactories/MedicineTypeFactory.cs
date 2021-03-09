using HMB_Domain.BusinessObjects;
using HMB_DA.Core;
using HMB_Domain.Criteria;

namespace HMB_DA.DomainFactories
{
    public class MedicineTypeFactory : AbstractNHibernateFactory<MedicineType>
    {
        public override MedicineType Fetch(object criteria)
        {
            var idCrit = (IdCriteria<int>)criteria;
            var obj = Session.Get<MedicineType>(idCrit.Value);
            obj.MakeOld();
            return obj;
        }
    }
}
