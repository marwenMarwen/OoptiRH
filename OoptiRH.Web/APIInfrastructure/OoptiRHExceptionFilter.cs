using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using OoptiRH.Kernel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OoptiRH.API.APIInfrastructure
{
    public class OoptiRHExceptionAttribute : ExceptionFilterAttribute
    {
        private readonly IlogRepository _logRepository;

        public OoptiRHExceptionAttribute(IlogRepository logrepository)
        {
            this._logRepository = logrepository;
        }

        public override void OnException(ExceptionContext context)
        {
            this._logRepository.LogError(context.Exception.Message);           
        }
    }
}
