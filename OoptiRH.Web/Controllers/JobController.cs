using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OoptiRH.Common.Dtos;
using OoptiRH.Kernel.SettingModels;
using OoptiRH.Manager.Interfaces;

namespace OoptiRH.API.Controllers
{
    [Produces("application/json")]
    [Route("Job")]
    public class JobController : OoptiRHController
    {
        private readonly IJobManager _jobManager;

        public JobController(
            IOptions<OoptiRHSettings> ooptiRHSettings,
            IJobManager jobManager
            ) : base(ooptiRHSettings)
        {
            this._jobManager = jobManager;
        }

        // GET: api/Job
        // implment pagination principal
        [HttpGet]
        public IEnumerable<JobDto> Get()
        {
            return this._jobManager.Get();
        }

        // GET: api/Job/5
        [HttpGet("{jobGuid}", Name = "Get")]
        public JobDto Get(Guid jobGuid)
        {
            return this._jobManager.GetByGuid(jobGuid);
        }

        // POST: api/Job
        [HttpPost]
        public void Post([FromBody]JobDto job)
        {
            this._jobManager.Add(job);
        }

        // PUT: api/Job/5
        [HttpPut]
        public void Put([FromBody]JobDto job)
        {
            this._jobManager.Update(job);
        }


    }
}
