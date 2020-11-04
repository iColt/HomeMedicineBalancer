using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Domain
{
    public class Medicine : Object
    {
        public virtual DateTime ValidTo { get; set; }

        public virtual int MedicineTypeId { get; set; }

    }
}
