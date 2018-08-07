using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Common.Dtos
{
    public class JobCollaboratorHistoryDto
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public CollaboratorDto Collaborator { get; set; }
        public JobDto Job { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
