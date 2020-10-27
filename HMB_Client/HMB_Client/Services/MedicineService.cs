using HMB_Client.Models;
using HMB_Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB_Client.Services
{
    public class MedicineService
    {
        private ObjectRepository _objectRepository;

        public MedicineService(ObjectRepository objectRepository)
        {
            _objectRepository = objectRepository;
        }

        public IList<Medicine> GetListMedicine()
        {
            var objs = _objectRepository.GetAll();

            return objs.Select(x =>
                new Medicine()
                { Id = x.Id, Code = x.Code, Name = x.Name, ValidTo = x.ValidTo }
                ).ToList();
        }

        public void Save(Medicine medicine)
        {
            var obj = new Domain.Object() { Code = medicine.Code, Name = medicine.Name, ValidTo = medicine.ValidTo };
            _objectRepository.Save(obj);
        }
    }
}
