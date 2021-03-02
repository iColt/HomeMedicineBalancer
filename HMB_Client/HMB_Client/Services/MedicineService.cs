﻿using HMB_Client.Interfaces;
using HMB_Client.Models;
using Domain = HMB_DA.Domain;
using System.Collections.Generic;
using HMB_DA.Interfaces;
using AutoMapper;

namespace HMB_Client.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;

        public MedicineService(IMedicineRepository medicineRepository, IMapper mapper)
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }

        //TODO: Medicine  collection
        public IList<Medicine> GetList()
        {
            var objs = _medicineRepository.GetAll();
            return _mapper.Map<IList<Medicine>>(objs);
        }

        public Medicine Save(Medicine medicine)
        {
            var obj = Domain.Medicine.New();
            if(medicine.Id != 0)
            {
                obj = _medicineRepository.GetById(medicine.Id);
            }
            _mapper.Map(medicine, obj);
            return _mapper.Map<Medicine>(obj.Save());
        }

        public void Delete(Medicine medicine)
        {
            var obj = Domain.Medicine.New();
            if (medicine.Id != 0)
            {
                obj = _medicineRepository.GetById(medicine.Id);
            }
            _mapper.Map(medicine, obj);
            obj.Delete();
        }
    }
}
