using HMB_Client.Interfaces;
using HMB_Client.Models;
using HMB_Client.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HMB_Client.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly ObjectRepository _objectRepository;

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
            var obj = new Domain.Object();
            if(medicine.Id != 0)
            {
                obj = _objectRepository.GetById(medicine.Id);
            }
            //TODO: add mapper here
            FillObject(obj, medicine);
            _objectRepository.Save(obj);
        }

        public void FillObject(Domain.Object obj, Medicine medicine)
        {
            obj.Code = medicine.Code;
            obj.Name = medicine.Name;
            obj.ValidTo = medicine.ValidTo;
        }

        public void Delete(Medicine medicine)
        {
            var obj = new Domain.Object();
            if (medicine.Id != 0)
            {
                obj = _objectRepository.GetById(medicine.Id);
            }
            //TODO: add mapper here
            FillObject(obj, medicine);
            _objectRepository.Delete(obj);
        }
    }
}
