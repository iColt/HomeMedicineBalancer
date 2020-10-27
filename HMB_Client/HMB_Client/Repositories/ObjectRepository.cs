using HMB_Client.Core;
using HMB_Client.Helpers;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain = HMB_Client.Domain;

namespace HMB_Client.Repositories
{
    public class ObjectRepository : SqLiteRepository<Domain.Object>//, IObjectRepository
    {
        #region ICustomerRepository members

        public IEnumerable<Domain.Object> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return CreateQuery(session).ToList();
            }
        }

        #endregion
    }
}
