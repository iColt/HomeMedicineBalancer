using HMB_Client.Domain;
using System;
using System.Collections.Generic;

namespace HMB_Client.Interfaces
{
    interface IMedicineRepository
    {
        IEnumerable<Medicine> GetAll();

        Medicine GetById(int id);
    }
}
