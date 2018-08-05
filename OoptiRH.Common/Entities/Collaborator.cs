using OoptiRH.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OoptiRH.Common.Entities
{
    public class Collaborator : Entity
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        public int AdresseId { get; set; }
        public Adresse Adresse { get; set; }
    }
}
