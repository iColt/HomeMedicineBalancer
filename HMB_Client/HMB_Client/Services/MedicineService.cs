using AutoMapper;
using HMB_Client.Interfaces;
using HMB_Client.Models;
using Domain = HMB_DA.Domain;
using System.Collections.Generic;
using HMS_DA.Domain;

namespace HMB_Client.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMapper _mapper;

        public MedicineService(IMapper mapper)
        {
            _mapper = mapper;
        }

        //TODO: Medicine  collection
        public IList<Medicine> GetList()
        {
            var objs = MedicineCollection.GetAll();
            return _mapper.Map<IList<Medicine>>(objs);
        }

        public Medicine Save(Medicine medicine)
        {
            Domain.Medicine obj;
            if(medicine.Id != 0) {
                obj = Domain.Medicine.Get(medicine.Id);
            }
            else {
                obj = Domain.Medicine.New();
            }
            _mapper.Map(medicine, obj);
            return _mapper.Map<Medicine>(obj.Save());
        }

        public void Delete(Medicine medicine)
        {
            Domain.Medicine obj;
            if (medicine.Id != 0)
            {
                obj = Domain.Medicine.Get(medicine.Id);
            }
            else
            {
                obj = Domain.Medicine.New();
            }
            _mapper.Map(medicine, obj);
            obj.Delete();
        }
    }
}
