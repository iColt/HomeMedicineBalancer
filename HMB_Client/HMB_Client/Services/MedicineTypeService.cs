using HMB_Client.Interfaces;
using HMB_Client.Models;
using System.Collections.Generic;
using HMS_DA.Interfaces;
using System.Linq;

namespace HMB_Client.Services
{
    public class MedicineTypeService : IMedicineTypeService
    {
        private readonly IMedicineTypeRepository _medicineTypeRepository;

        public MedicineTypeService(IMedicineTypeRepository medicineTypeRepository)
        {
            _medicineTypeRepository = medicineTypeRepository;
        }

        public IList<MedicineType> GetList()
        {
            var objs = _medicineTypeRepository.GetAll();

            return objs.Select(x =>
                new MedicineType()
                {
                    Id = x.Id,
                    Name = x.Name
                }
                ).ToList();
        }
    }
}
