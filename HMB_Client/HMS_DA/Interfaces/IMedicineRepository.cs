using HMB_DA.Domain;
using System.Collections.Generic;

namespace HMB_DA.Interfaces
{
    public interface IMedicineRepository : IRepository<Medicine>
    {
        IEnumerable<Medicine> GetAll();
    }
}
