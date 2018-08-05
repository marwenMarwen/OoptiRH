using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OoptiRH.Common.Entities
{
    public class Job : Entity
    {
        [Required]
        public string title { get; set; }
        public string Description { get; set; }
    }
}
