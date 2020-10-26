using HMB_Client.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Domain = HMB_Client.Domain;

namespace HMB_Client.Repositories
{
	public class ObjectRepository : SqLiteRepository<Domain.Object>//, IObjectRepository
	{
		#region ICustomerRepository members

		public IEnumerable<Domain.Object> GetAll()
		{
			return CreateQuery();
		}

		#endregion
	}
}
