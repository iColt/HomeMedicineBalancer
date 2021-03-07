using HMB_DA.Domain;
using HMS_DA.Core;
using HMS_DA.Criteria;

namespace HMS_DA.DomainFactories
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
