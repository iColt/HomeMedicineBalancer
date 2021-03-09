using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    public interface IMedicineService : IDataService
    {
        IList<MedicineModel> GetList();

        MedicineModel Save(MedicineModel medicine);

        void Delete(MedicineModel medicine);

    }
}
