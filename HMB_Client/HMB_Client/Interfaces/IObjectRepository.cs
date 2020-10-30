using System;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    interface IObjectRepository
    {
        IEnumerable<Domain.Object> GetAll();

        Domain.Object GetById(int id);
    }
}
