using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OoptiRH.API.APIInfrastructure;
using OoptiRH.Kernel.SettingModels;

namespace OoptiRH.API.Controllers
{

    [ServiceFilter(typeof(OoptiRHExceptionAttribute))]
    public class OoptiRHController : Controller
    {
        protected readonly OoptiRHSettings _ooptiRHSettings;

        public OoptiRHController(IOptions<OoptiRHSettings> ooptiRHSettings)
        {
            this._ooptiRHSettings = ooptiRHSettings.Value;
        }
    }
}