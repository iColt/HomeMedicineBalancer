using HMB_DA.Domain;
using HMB_DA.Interfaces;
using System.Collections.Generic;

namespace HMS_DA.Interfaces
{
    public interface IMedicineTypeRepository : IRepository<MedicineType>
    {
        IEnumerable<MedicineType> GetAll();
    }
}
