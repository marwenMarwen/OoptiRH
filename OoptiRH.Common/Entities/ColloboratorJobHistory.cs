using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Common.Entities
{
    public class ColloboratorJobHistory : Entity
    {
        public int CollaboratorId { get; set; }
        public Collaborator Collaborator { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
