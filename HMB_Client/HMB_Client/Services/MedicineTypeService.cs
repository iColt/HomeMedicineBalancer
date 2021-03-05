using HMB_Client.Interfaces;
using HMB_Client.Models;
using System.Collections.Generic;
using HMS_DA.Interfaces;
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

        //TODO: Medicine type collection
        public IList<MedicineType> GetList()
        {

            // var objs = MedicineTypeCollection.GetByIds(new List<int>());
            var objs = MedicineTypeCollection.GetAll();
            return _mapper.Map<IList<MedicineType>>(objs);
        }
    }
}
