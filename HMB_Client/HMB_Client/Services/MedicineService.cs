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
        private readonly MedicineRepository _medicineRepository;

        public MedicineService(MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public IList<Medicine> GetListMedicine()
        {
            var objs = _medicineRepository.GetAll();

            return objs.Select(x =>
                new Medicine()
                { Id = x.Id, Code = x.Code, Name = x.Name,
                ValidTo = x.ValidTo, MedicineTypeId = x.MedicineTypeId,
                CreatedDate = x.CreatedDate }
                ).ToList();
        }

        public void Save(Medicine medicine)
        {
            var obj = new Domain.Medicine();
            if(medicine.Id != 0)
            {
                obj = _medicineRepository.GetById(medicine.Id);
            }
            //TODO: add mapper here
            FillObject(obj, medicine);
            _medicineRepository.Save(obj);
        }

        public void FillObject(Domain.Medicine obj, Medicine medicine)
        {
            obj.Code = medicine.Code;
            obj.Name = medicine.Name;
            obj.MedicineTypeId = medicine.MedicineTypeId;
            obj.ValidTo = medicine.ValidTo;
            obj.CreatedDate = medicine.CreatedDate;
        }

        public void Delete(Medicine medicine)
        {
            var obj = new Domain.Medicine();
            if (medicine.Id != 0)
            {
                obj = _medicineRepository.GetById(medicine.Id);
            }
            //TODO: add mapper here
            FillObject(obj, medicine);
            _medicineRepository.Delete(obj);
        }
    }
}
