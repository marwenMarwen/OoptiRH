using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OoptiRH.Common.Entities
{
    public class Adresse:Entity
    {
        [Required]
        public string AdresseLine1 { get; set; }
        [Required]
        public string AdresseLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
