using CommonServiceLocator;
using Csla.Core;
using Csla.Server;
using HMS_DA.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMS_DA.Core
{
    public class GenericFactory<T> : ObjectFactory where T : class
	{
		#region Internal

		internal object Create()
		{
			try
			{
				var concreteFactory = GetConcreteFactory();
				var obj = concreteFactory.Create();

				if (obj != null)
				{
					MarkNew(obj);
				}
				return obj;
			}
			catch (Exception ex)
			{
				throw new Exception("Error while creating object", ex);
			}
		}

		private IDomainObjectFactory<T> GetConcreteFactory()
		{
			IDomainObjectFactory<T> concreteFactory = null;

			try
			{
				concreteFactory = ServiceLocator.Current.GetInstance<IDomainObjectFactory<T>>();
			}
			catch (Exception e)
			{
				throw new InvalidOperationException(String.Format("Cannot resolve {0} from service locator.", typeof(IDomainObjectFactory<T>).FullName), e);
			}

			if (concreteFactory == null)
			{
				throw new InvalidOperationException(String.Format("Cannot resolve {0} from service locator.", typeof(IDomainObjectFactory<T>).FullName));
			}

			return concreteFactory;
		}

		internal object Fetch(object criteria)
		{
			try
			{
				var concreteFactory = GetConcreteFactory();

				var obj = concreteFactory.Fetch(criteria as ICriteria);

				if (obj != null)
				{
					//TODO: introduce methods
					//obj.MarkChildrenAsOld();
					//obj.MarkOld();
				}

				return obj;
			}
			catch (Exception ex)
			{
				throw new Exception("Error while creating object", ex);
			}
		}

		#endregion
	}
}
