using System;
using System.Collections.Generic;
using System.Text;

namespace OoptiRH.Kernel.Logging
{
    public interface IlogRepository
    {
        void LogInfo(String info);
        void LogError(String error);

    }
}
