using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public virtual int MedicineTypeId { get; set; }

        public DateTime ValidTo { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
