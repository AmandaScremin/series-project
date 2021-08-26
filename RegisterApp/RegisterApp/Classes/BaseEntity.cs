using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterApp
{
    public abstract class BaseEntity
    {
        //this class will only have an id, so every heir will have it as well
        public int Id { get; protected set; }
    }
}
