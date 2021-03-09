using HMB_Client.Interfaces;
using HMB_Client.Models;
using System.Collections.Generic;
using AutoMapper;
using HMS_DA.Domain;

namespace HMB_Client.Services
{
    public class MedicineTypeService : IMedicineTypeService
    {
        private readonly IMapper _mapper;

        public MedicineTypeService( IMapper mapper)
        {
            _mapper = mapper;
        }

        public IList<MedicineTypeModel> GetList()
        {

            var objs = MedicineTypeCollection.GetAll();
            return _mapper.Map<IList<MedicineTypeModel>>(objs);
        }
    }
}
