using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Common.Dtos
{
    public class JobDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
    }
}
