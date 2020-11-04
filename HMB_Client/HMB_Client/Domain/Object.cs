using System;
using System.Collections.Generic;
using System.Text;

namespace HMB_Client.Domain
{
    public abstract class Object
    {
        public virtual int Id { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime CreatedDate { get; set; }

    }
}
