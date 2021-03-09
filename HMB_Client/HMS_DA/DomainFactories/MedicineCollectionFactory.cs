using HMB_Domain.BusinessObjects;
using HMS_DA.Core;
using HMB_Domain.Criteria;
using System.Collections.Generic;
using System.Linq;

namespace HMS_DA.DomainFactories
{
    public class MedicineCollectionFactory : AbstractNHibernateCollectionFactory<MedicineCollection>
    {
        public override MedicineCollection Fetch(object criteria)
        {
            var result = MedicineCollection.New();
            var nHibernateCriteria = Session.CreateCriteria<Medicine>();
            if (criteria is CollectionByIdCriteria<IEnumerable<int>, int>)
            {
                var idCrit = (CollectionByIdCriteria<IEnumerable<int>, int>)criteria;

                if (idCrit != null)
                {
                    nHibernateCriteria.Add(NHibernate.Criterion.Expression.InG<int>("Id", idCrit.Value.ToList()));
                }
            }

            var queryResult = Session.Query<Medicine>().ToList();
            queryResult.ForEach(x => x.AsChild());
            result.AddRange(queryResult);
            return result;
        }
    }
}
