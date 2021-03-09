using HMB_Client.Models;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    public interface IMedicineTypeService : IDataService
    {
        IList<MedicineTypeModel> GetList();
    }
}
