using OoptiRH.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Manager.Interfaces
{
    public interface IJobManager
    {
        /// <summary>
        /// Add a new Job to the data base
        /// </summary>
        /// <param name="job">the new job</param>
        void Add(JobDto job);

        /// <summary>
        /// Update an existing Job
        /// </summary>
        /// <param name="job">the job with new value</param>
        void Update(JobDto job);

        /// <summary>
        /// Get a job by it's GUID
        /// </summary>
        /// <param name="jobGuid">the job GUID</param>
        /// <returns>the selected job</returns>
        JobDto GetByGuid(Guid jobGuid);

        /// <summary>
        /// Get a job by it's Id
        /// </summary>
        /// <param name="jobID">Job's Id</param>
        /// <returns>the selected Job</returns>
        JobDto GetById(int jobID);

        /// <summary>
        /// Get All jobs
        /// </summary>
        /// <returns>All jobs in the database</returns>
        IEnumerable<JobDto> Get();
    }
}
