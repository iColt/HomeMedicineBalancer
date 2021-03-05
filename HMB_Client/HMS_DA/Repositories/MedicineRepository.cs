using HMB_DA.Domain;
using HMB_DA.Interfaces;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace HMS_DA.Repositories
{
    public class MedicineRepository : SqLiteRepository<Medicine>
    {
        public MedicineRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }


        #region ICustomerRepository members

        public IEnumerable<Medicine> GetAll()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return CreateQuery(session).ToList();
            }
        }

        #endregion
    }
}
