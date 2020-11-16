using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    public interface ICacheService
    {

        IList<MedicineType> MedicineTypes { get; set; }

        void Load();

        MedicineType GetMedicineType(int id);

    }
}
