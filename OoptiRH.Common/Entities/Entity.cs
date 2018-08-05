using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Common.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
    }
}
