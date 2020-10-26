using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Helpers
{
    public static class NHibernateHelper
    {
        public static ISessionFactory SessionFactory { get; set; }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
