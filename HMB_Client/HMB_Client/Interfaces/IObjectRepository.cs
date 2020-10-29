using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Interfaces
{
    interface IObjectRepository
    {
        IEnumerable<Domain.Object> GetAll();
    }
}
