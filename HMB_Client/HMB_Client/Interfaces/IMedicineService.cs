using HMB_Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Interfaces
{
    public interface IMedicineService
    {
        IList<Medicine> GetListMedicine();
        void Save(Medicine medicine);

    }
}
