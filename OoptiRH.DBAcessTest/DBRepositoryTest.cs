using Microsoft.EntityFrameworkCore;
using Moq;
using OoptiRH.Common.Entities;
using OoptiRH.DBAcess.Implementations;
using OoptiRH.DBAcess.Interfaces;
using System;
using System.Linq;
using Xunit;

namespace OoptiRH.DBAcessTest
{
    public class DBRepositoryTest
    {

        [Fact]
        public void Insert_NewJobEntity_EntityInserted()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<OoptiRHContext>()
                .UseInMemoryDatabase(databaseName: "InsertNewJobEntityEntityInserted")
                .Options;

            Job NewJob = new Job
            {
                Guid = Guid.NewGuid(),
                title = "Senior .Net developper",
                Description = "a .net how has a signeficant experience",
            };

            //Act
            using (var context = new OoptiRHContext(options))
            {
                IDBRepository<Job> jobRepository = new DBRepository<Job>(context);
                jobRepository.Insert(NewJob);
            }

            //Assert
            using (var context = new OoptiRHContext(options))
            {
                int count = context.Jobs.CountAsync().Result;
                Assert.Equal(1, count);
            }
        }

        [Fact]
        public void Update_ExistingEntity_EntityUpdated()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<OoptiRHContext>()
                .UseInMemoryDatabase(databaseName: "UpdateExistingEntityEntityUpdated")
                .Options;

            Job NewJob = new Job
            {
                Guid = Guid.NewGuid(),
                title = "Senior .Net developper",
                Description = "a .net how has a signeficant experience",
            };
            Job selectedJob = null;

            
            using (var context = new OoptiRHContext(options))
            {
                IDBRepository<Job> jobRepository = new DBRepository<Job>(context);
                jobRepository.Insert(NewJob);

                selectedJob = jobRepository.GetAll().FirstOrDefault();
                
                if (selectedJob != null)
                {
                    selectedJob.title = ".Net Architecture";
                    selectedJob.Description = "A software dovelopper how master the framwork";
                }
             
                //act
                jobRepository.Update(selectedJob);
            }

            
            using (var context = new OoptiRHContext(options))
            {
                IDBRepository<Job> jobRepository = new DBRepository<Job>(context);               
                selectedJob = jobRepository.GetAll().FirstOrDefault();

                Assert.Equal(".Net Architecture", selectedJob.title);
                Assert.Equal("A software dovelopper how master the framwork", selectedJob.Description);
            }


        }
    }
}
