using System;

namespace HMB_Client.Models
{
    public class MedicineModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public virtual int MedicineTypeId { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime CreatedDate { get; set; }

        public MedicineTypeModel MedicineType { get; set; }

    }
}
