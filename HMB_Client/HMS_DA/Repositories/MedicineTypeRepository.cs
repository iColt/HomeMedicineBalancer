using System.Linq;
using HMB_DA.Domain;
using HMS_DA.Interfaces;
using NHibernate;
using System.Collections.Generic;

namespace HMS_DA.Repositories
{
    public class MedicineTypeRepository : SqLiteRepository<MedicineType>
    {
        public MedicineTypeRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }


        #region ICustomerRepository members

        public IEnumerable<MedicineType> GetAll()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return CreateQuery(session).ToList();
            }
        }

        #endregion
    }
}
