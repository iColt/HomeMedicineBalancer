using HMB_Client.Core;
using HMB_Client.Domain;
using HMB_Client.Helpers;
using HMB_Client.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain = HMB_Client.Domain;

namespace HMB_Client.Repositories
{
    public class MedicineRepository : SqLiteRepository<Medicine>, IMedicineRepository
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
