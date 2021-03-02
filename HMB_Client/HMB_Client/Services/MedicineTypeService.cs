using HMB_Client.Interfaces;
using HMB_Client.Models;
using System.Collections.Generic;
using HMS_DA.Interfaces;
using AutoMapper;

namespace HMB_Client.Services
{
    public class MedicineTypeService : IMedicineTypeService
    {
        private readonly IMedicineTypeRepository _medicineTypeRepository;
        private readonly IMapper _mapper;

        public MedicineTypeService(IMedicineTypeRepository medicineTypeRepository, IMapper mapper)
        {
            _medicineTypeRepository = medicineTypeRepository;
            _mapper = mapper;
        }

        //TODO: Medicine type collection
        public IList<MedicineType> GetList()
        {
            var objs = _medicineTypeRepository.GetAll();
            return _mapper.Map<IList<MedicineType>>(objs);
        }
    }
}
