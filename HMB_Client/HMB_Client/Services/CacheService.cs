using HMB_Client.Interfaces;
using HMB_Client.Models;
using System.Collections.Generic;
using System.Linq;

namespace HMB_Client.Services
{
    public class CacheService : ICacheService
    {

        private readonly IMedicineTypeService medicineTypeService;

        public IList<MedicineType> MedicineTypes { get; set; } = new List<MedicineType>(); 

        public CacheService(IMedicineTypeService medicineTypeService)
        {
            this.medicineTypeService = medicineTypeService;
        }

        public MedicineType GetMedicineType(int id)
        {
            return MedicineTypes.FirstOrDefault(x => x.Id == id);
        }

        public void Load()
        {
            MedicineTypes = medicineTypeService.GetList();
        }
    }
}
