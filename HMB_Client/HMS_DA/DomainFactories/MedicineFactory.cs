using HMB_DA.Domain;
using HMS_DA.Core;
using HMS_DA.Criteria;

namespace HMS_DA.DomainFactories
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
