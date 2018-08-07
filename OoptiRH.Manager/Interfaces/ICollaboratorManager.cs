using OoptiRH.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Manager.Interfaces
{
    public interface ICollaboratorManager
    {
        /// <summary>
        /// Get All collaborator
        /// </summary>
        /// <returns>All collaborator</returns>
        IEnumerable<CollaboratorDto> GetAllCollaborator();
 
        /// <summary>
        /// Insert a new collaborator in Database
        /// </summary>
        /// <param name="collaborator">the new Collaborator</param>
        void AddCollaborator(CollaboratorDto collaborator);

        /// <summary>
        /// Update an existing collaborator
        /// </summary>
        /// <param name="collaborator"></param>
        void UpdateCollaborator(CollaboratorDto collaborator);

        /// <summary>
        /// Delete a collaborator from Database
        /// </summary>
        /// <param name="CollaboratorGuid">the Collaborator GUID</param>
        void DeleteCollaborator(Guid CollaboratorGuid);

    }
}
