using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Domain
{
    public class Object
    {
        public virtual int Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime ValidTo { get; set; }
    }
}
