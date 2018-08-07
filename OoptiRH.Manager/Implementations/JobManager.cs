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
    public class JobManager : IJobManager
    {
        private readonly IDBRepository<Job> _jobRepository;
        private readonly IMapper _ooptiRHMapper;

        public JobManager(IDBRepository<Job> jobRepository, IMapper ooptiRHMapper)
        {
            this._jobRepository = jobRepository;
            this._ooptiRHMapper = ooptiRHMapper;
        }

        public void Add(JobDto job)
        {
            job.Guid = Guid.NewGuid();
            this._jobRepository.Insert(
                this._ooptiRHMapper.Map<Job>(job)
                );
        }

        public IEnumerable<JobDto> Get()
        {
            var jobs = this._jobRepository.GetAll();
            return this._ooptiRHMapper.Map<IEnumerable<JobDto>>(jobs);
        }

        public JobDto GetByGuid(Guid jobGuid)
        {
            var selectedJob = this._jobRepository.GetBy(j => j.Guid.Equals(jobGuid)).FirstOrDefault();
            return this._ooptiRHMapper.Map<JobDto>(selectedJob);
        }

        public JobDto GetById(int jobID)
        {
            var selectedJob = this._jobRepository.GetByID(jobID);
            return this._ooptiRHMapper.Map<JobDto>(selectedJob);
        }

        public void Update(JobDto job)
        {
            var selectedJob = this._jobRepository.GetByID(job.Id);
            selectedJob.title = job.title;
            selectedJob.Description = job.Description;
            selectedJob.LastUpdateDate = DateTime.Now;

            this._jobRepository.Update(selectedJob);
        }
    }
}
