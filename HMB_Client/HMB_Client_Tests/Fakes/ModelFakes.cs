using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client_Tests.Fakes
{
    public static class ModelFakes
    {
        public static IList<MedicineType> GetMedicineTypes()
        {
            //TODO: create name constants
            return new List<MedicineType> {
                new MedicineType { Id = 1, Name = "Таблетки"},
                new MedicineType { Id = 2, Name = "Пилюли"}
            };
        }

        public static IList<Medicine> GetMedicines()
        {
            return new List<Medicine>
            {
                new Medicine { Id = 1, Name = "Name1", Code = "NM1", MedicineTypeId = 1},
                new Medicine { Id = 2, Name = "Name2", Code = "NM2", MedicineTypeId = 1},
                new Medicine { Id = 3, Name = "Name3", Code = "NM3", MedicineTypeId = 2}
            };
        }
    }
}
