using AutoMapper;
using Moq;
using OoptiRH.Common.Dtos;
using OoptiRH.Common.Entities;
using OoptiRH.DBAcess.Interfaces;
using OoptiRH.Manager.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace OoptiRH.ManagerTest
{

    public class JobManagerTest
    {
        private readonly Mock<IDBRepository<Job>> _jobRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private  List<Job> _jobsMock;
        private Job _job;
        

        //With xunit we don't have a [SetUp] attribute 
        public JobManagerTest()
        {
            this._jobRepositoryMock = new Mock<IDBRepository<Job>>();
            this._mapperMock = new Mock<IMapper>();

            this._job = new Job()
            {
                Id = 1,
                Guid = Guid.NewGuid(),
                title = "Software developper",
                Description = "Developping software applications",
                CreationDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
            };
            

            this._jobsMock = new List<Job>();
            this._jobsMock.Add(this._job);

            this._mapperMock.Setup(map => map.Map<JobDto>(It.IsAny<Job>()))
                   .Returns((Job job) => new JobDto
                   {
                       Id = job.Id,
                       Guid = job.Guid,
                       title = job.title,
                       Description = job.Description,
                       CreationDate = job.CreationDate,
                       LastUpdateDate = job.LastUpdateDate
                   });

            //this._mapperMock.Setup(map => map.Map<IEnumerable<JobDto>>(It.IsAny<IEnumerable<Job>>()) >)
            //    .Returns((IEnumerable<Job> jo ConvertToJobDto(jobs).AsQueryable() );

            this._jobRepositoryMock.Setup(repo => repo.GetByID(It.IsAny<object>()))
               .Returns((int id) => this._jobsMock.FirstOrDefault(j => j.Id == id));
        }

        [Fact]
        public void GetById_ExistingJobGuid_NotNullJob()
        {
            //arrange
            var jobManager = new JobManager(this._jobRepositoryMock.Object, this._mapperMock.Object);

            //act
            var selectedJobs = jobManager.GetById(1);

            //assert
            Assert.IsType<JobDto>(selectedJobs);
            Assert.True(compareJobs(selectedJobs,this._job));
        }


        private bool compareJobs(JobDto jobDto, Job job)
        {
            return jobDto.Id == job.Id
                && jobDto.Guid.Equals(job.Guid)
                && jobDto.title.Equals(job.title)
                && jobDto.Description.Equals(job.Description)
                && jobDto.CreationDate.Equals(job.CreationDate)
                && jobDto.LastUpdateDate.Equals(job.LastUpdateDate);
        }
    }
}
