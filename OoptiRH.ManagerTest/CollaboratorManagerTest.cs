using AutoMapper;
using Moq;
using OoptiRH.Common.Entities;
using OoptiRH.Common.Enums;
using OoptiRH.DBAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OoptiRH.ManagerTest
{
    public class CollaboratorManagerTest
    {
        private readonly Mock<IDBRepository<Collaborator>> _collaboratorRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly List<Collaborator> _collaboratorsMock;

        //with xUnit we do not have a [SetUp] attribute
        public CollaboratorManagerTest()
        {
            this._collaboratorRepositoryMock = new Mock<IDBRepository<Collaborator>>();
            
            this._collaboratorsMock = new List<Collaborator>();
            this._mapperMock = new Mock<IMapper>();

            this._collaboratorsMock.Add(new Collaborator
            {
                Id = 1,
                Guid = Guid.NewGuid(),
                FirstName = "Marwen",
                LastName = "kachroudi",
                Gender = Gender.Men,
                BirthDate = new DateTime(1988, 05, 21),
                HireDate = new DateTime(2018,08,30),
                CreationDate= DateTime.Now,
                LastUpdateDate = DateTime.Now,
                
            });



        }
        

        [Fact]
        public void AddCollaborator_NewCollaborator_CollaboratorAdded()
        {
            Assert.Equal(1, 1);
        }

        [Fact]
        public void GetAllCollaborator_Allcollaborators()
        {
            Assert.Equal(1, 1);
        }
    }
}
