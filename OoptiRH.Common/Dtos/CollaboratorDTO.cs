using OoptiRH.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Common.Dtos
{
    public class CollaboratorDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }       
        public AdresseDto Adresse { get; set; }
    }
}
