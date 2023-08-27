using ControllerLib_DotNetFramework.Interfaces.Controller;
using ControllerLib_DotNetFramework.Loger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Interfaces.Logger
{
    public interface ILogger
    {
        ILog Create(IOperationResult result);

        void SaveLogToCollection(IOperationResult result ,IEnumerable<ILog> logs);

        void SaveLog(ILog log, ILogSaver saver);
    }
}
