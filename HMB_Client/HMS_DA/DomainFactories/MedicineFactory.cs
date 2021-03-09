using HMB_Domain.BusinessObjects;
using HMB_DA.Core;
using HMB_Domain.Criteria;

namespace HMB_DA.DomainFactories
{

    public class MedicineFactory : AbstractNHibernateFactory<Medicine>
    {
        public override Medicine Fetch(object criteria)
        {
            var idCrit = (IdCriteria<int>)criteria;
            var obj = Session.Get<Medicine>(idCrit.Value);
            obj.MakeOld();
            return obj;
        }
    }
}
