using System;

namespace HMB_DA.Domain
{
    public class Medicine : Object
    {
        public virtual DateTime ValidTo { get; set; }

        public virtual int MedicineTypeId { get; set; }

    }
}
