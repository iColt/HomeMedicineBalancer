using HMB_Client.Core;
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
    public class ObjectRepository : SqLiteRepository<Domain.Object>, IObjectRepository
    {
        public ObjectRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }


        #region ICustomerRepository members

        public IEnumerable<Domain.Object> GetAll()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return CreateQuery(session).ToList();
            }
        }

        #endregion
    }
}
