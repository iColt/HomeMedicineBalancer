using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Domain
{
    public class Object
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime ValidTo { get; set; }
    }
}
