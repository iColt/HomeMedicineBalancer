using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    public interface IMedicineService
    {
        IList<Medicine> GetListMedicine();
        void Save(Medicine medicine);

        void Delete(Medicine medicine);

    }
}
