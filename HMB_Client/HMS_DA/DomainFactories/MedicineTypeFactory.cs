using HMB_DA.Domain;
using HMS_DA.Core;
using HMS_DA.Criteria;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_DA.DomainFactories
{
    public class MedicineTypeFactory : AbstractNHibernateFactory<MedicineType>
    {
        public override MedicineType Fetch(object criteria)
        {
            var idCrit = (IdCriteria<int>)criteria;
            return Session.Get<MedicineType>(idCrit.Value);
        }
    }
}
