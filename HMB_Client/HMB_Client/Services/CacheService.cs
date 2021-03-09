using HMB_Client.Interfaces;
using HMB_Client.Models;
using System.Collections.Generic;
using System.Linq;

namespace HMB_Client.Services
{
    public class CacheService : ICacheService
    {

        private readonly IMedicineTypeService medicineTypeService;

        public IList<MedicineTypeModel> MedicineTypes { get; set; } = new List<MedicineTypeModel>(); 

        public CacheService(IMedicineTypeService medicineTypeService)
        {
            this.medicineTypeService = medicineTypeService;
        }

        public MedicineTypeModel GetMedicineType(int id)
        {
            return MedicineTypes.FirstOrDefault(x => x.Id == id);
        }

        public void Load()
        {
            MedicineTypes = medicineTypeService.GetList();
        }
    }
}
