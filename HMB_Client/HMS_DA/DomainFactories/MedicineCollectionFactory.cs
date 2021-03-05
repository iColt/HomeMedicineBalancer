using HMB_DA.Domain;
using HMS_DA.Core;
using HMS_DA.Criteria;
using HMS_DA.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMS_DA.DomainFactories
{
    public class MedicineCollectionFactory : AbstractNHibernateCollectionFactory<MedicineCollection>
    {
        public override MedicineCollection Fetch(ICriteria criteria)
        {
            var result = MedicineCollection.New();
            var nHibernateCriteria = Session.CreateCriteria<Medicine>();
            var idCrit = (CollectionByIdCriteria<IEnumerable<int>, int>)criteria;

            if (idCrit != null)
            {
                nHibernateCriteria.Add(NHibernate.Criterion.Expression.InG<int>("Id", idCrit.Value.ToList()));
            }
            result.AddRange(nHibernateCriteria
                .List<Medicine>());
            return result;
        }
    }
}
