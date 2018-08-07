using AutoMapper;
using OoptiRH.Common.Dtos;
using OoptiRH.Common.Entities;
using OoptiRH.DBAcess.Interfaces;
using OoptiRH.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OoptiRH.Manager.Implementations
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly IDBRepository<Collaborator> _collaboratorRepository;
        private readonly IMapper _ooptiRHMapper;

        public CollaboratorManager(IDBRepository<Collaborator> collaboratorRepository, IMapper mapper)
        {
            this._collaboratorRepository = collaboratorRepository;
            this._ooptiRHMapper = mapper;
        }

        
        public void AddCollaborator(CollaboratorDto collaborator)
        {
            this._collaboratorRepository.Insert(
                this._ooptiRHMapper.Map<Collaborator>(collaborator)
                );
        }

        
        public void DeleteCollaborator(Guid CollaboratorGuid)
        {
            var selectedCollaborator = this._collaboratorRepository.GetBy(c => c.Guid.Equals(CollaboratorGuid)).FirstOrDefault();
            this._collaboratorRepository.Delete(selectedCollaborator.Id);
        }

        
        public IEnumerable<CollaboratorDto> GetAllCollaborator()
        {
            var collaborators = this._collaboratorRepository.GetAll();
            return this._ooptiRHMapper.Map<IEnumerable<CollaboratorDto>>(collaborators);
        }

        
        public void UpdateCollaborator(CollaboratorDto collaborator)
        {
            var selectedCollaborator = this._collaboratorRepository.GetBy(c => c.Guid.Equals(collaborator.Guid)).FirstOrDefault();
            if (selectedCollaborator != null)
            {
                selectedCollaborator.FirstName = collaborator.FirstName;
                selectedCollaborator.LastName = collaborator.LastName;
                selectedCollaborator.Adresse = this._ooptiRHMapper.Map<Adresse>(collaborator.Adresse);
                selectedCollaborator.BirthDate = collaborator.BirthDate;
                selectedCollaborator.Gender = collaborator.Gender;
                selectedCollaborator.HireDate = collaborator.HireDate;
                selectedCollaborator.LastUpdateDate = DateTime.Now;
            }

            this._collaboratorRepository.Update(selectedCollaborator);
        }
    }
}
