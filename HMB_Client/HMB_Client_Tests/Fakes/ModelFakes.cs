using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client_Tests.Fakes
{
    public static class ModelFakes
    {
        public static IList<MedicineTypeModel> GetMedicineTypes()
        {
            //TODO: create name constants
            return new List<MedicineTypeModel> {
                new MedicineTypeModel { Id = 1, Name = "Таблетки"},
                new MedicineTypeModel { Id = 2, Name = "Пилюли"}
            };
        }

        public static IList<MedicineModel> GetMedicines()
        {
            return new List<MedicineModel>
            {
                new MedicineModel { Id = 1, Name = "Name1", Code = "NM1", MedicineTypeId = 1},
                new MedicineModel { Id = 2, Name = "Name2", Code = "NM2", MedicineTypeId = 1},
                new MedicineModel { Id = 3, Name = "Name3", Code = "NM3", MedicineTypeId = 2}
            };
        }
    }
}
