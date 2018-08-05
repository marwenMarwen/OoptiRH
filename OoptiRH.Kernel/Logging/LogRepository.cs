using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OoptiRH.Kernel.Logging
{
    public class LogRepository : IlogRepository
    {
        private readonly ILog _logger;

        public LogRepository()
        {            

            this._logger = LogManager.GetLogger(typeof(LogRepository));


            this._logger.Error("Hello World!");
        }

        public void LogError(string error)
        {
            this._logger.Error(error);
        }

        public void LogInfo(string info)
        {
            this._logger.Info(info);
        }
    }
}
