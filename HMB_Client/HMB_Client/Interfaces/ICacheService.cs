using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    public interface ICacheService
    {

        IList<MedicineTypeModel> MedicineTypes { get; set; }

        void Load();

        MedicineTypeModel GetMedicineType(int id);

    }
}
