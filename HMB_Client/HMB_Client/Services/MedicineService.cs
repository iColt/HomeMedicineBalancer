using AutoMapper;
using HMB_Client.Interfaces;
using HMB_Client.Models;
using Domain = HMB_DA.Domain;
using System.Collections.Generic;
using HMS_DA.Domain;
using HMB_DA.Domain;

namespace HMB_Client.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMapper _mapper;

        public MedicineService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IList<MedicineModel> GetList()
        {
            var objs = MedicineCollection.GetAll();
            return _mapper.Map<IList<MedicineModel>>(objs);
        }

        public MedicineModel Save(MedicineModel medicine)
        {
            Medicine obj;
            if(medicine.Id != 0) {
                obj = Medicine.Get(medicine.Id);
            }
            else {
                obj = Medicine.New();
            }
            _mapper.Map(medicine, obj);
            return _mapper.Map<MedicineModel>(obj.Save());
        }

        public void Delete(MedicineModel medicine)
        {
            Medicine obj;
            if (medicine.Id != 0)
            {
                obj = Medicine.Get(medicine.Id);
            }
            else
            {
                obj = Medicine.New();
            }
            _mapper.Map(medicine, obj);
            obj.Delete();
        }
    }
}
