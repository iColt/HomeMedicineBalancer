using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    public interface IMedicineService : IDataService
    {
        IList<Medicine> GetList();

        Medicine Save(Medicine medicine);

        void Delete(Medicine medicine);

    }
}
