using ControllerLib_DotNetFramework.Interfaces.Controller;
using ControllerLib_DotNetFramework.Interfaces.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Loger
{
    public class Logger : ILogger
    {
        public virtual ILog Create(IOperationResult result)
        {
            if (result == null)
                return null;

            return new Log(Guid.NewGuid(), DateTime.Now, result.Name,
            result.Exception, result.ExecutionState);
        }

        public virtual void SaveLog(IOperationResult result, ILogSaver saver)
        {
            saver.Save(result);
        }

        public virtual void SaveLogToCollection(IOperationResult result, IEnumerable<ILog> logs)
        {
            if(result == null && logs == null)
                return;

            logs.Append(Create(result));
        }
    }
}
