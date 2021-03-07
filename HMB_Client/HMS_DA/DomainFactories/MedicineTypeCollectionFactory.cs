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
    public class MedicineTypeCollectionFactory : AbstractNHibernateCollectionFactory<MedicineTypeCollection>
    {
        public override MedicineTypeCollection Fetch(object criteria)
        {
            var result = MedicineTypeCollection.New();
            var nHibernateCriteria = Session.CreateCriteria<MedicineType>();
            if(criteria is CollectionByIdCriteria<IEnumerable<int>, int>)
            {
                var idCrit = (CollectionByIdCriteria<IEnumerable<int>, int>)criteria;

                if (idCrit != null)
                {
                    nHibernateCriteria.Add(NHibernate.Criterion.Expression.InG<int>("Id", idCrit.Value.ToList()));
                }
            }
           
            var queryResult = nHibernateCriteria
                .List<MedicineType>().ToList();
            queryResult.ForEach(x => x.AsChild());
            result.AddRange(queryResult);
            return result;
        }
    }
}
