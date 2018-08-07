using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Common.Dtos
{
    public class AdresseDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string AdresseLine1 { get; set; }
        public string AdresseLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
