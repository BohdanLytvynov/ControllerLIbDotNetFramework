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
        /// <summary>
        /// Creates Log according to operation execition result
        /// </summary>
        /// <param name="result">Operation result</param>
        /// <returns>ILog object</returns>
        public virtual ILog Create(IOperationResult result)
        {
            if (result == null)
                return null;

            return new Log(Guid.NewGuid(), DateTime.Now, result.Name,
            result.Exception, result.ExecutionState);
        }

        /// <summary>
        /// Saves Log. Dependency Injection principle can be used to determine the way how to save Log
        /// </summary>
        /// <param name="log">ILog object for saving</param>
        /// <param name="saver">IlogSaver object</param>
        public virtual void SaveLog(ILog log, ILogSaver saver)
        {
            saver.Save(log);
        }

        /// <summary>
        /// Saves Log to the collection of Logs
        /// </summary>
        /// <param name="result">Operation Result</param>
        /// <param name="logs">Log collection</param>
        public virtual void SaveLogToCollection(IOperationResult result, IEnumerable<ILog> logs)
        {
            if(result == null && logs == null)
                return;

            logs.Append(Create(result));
        }
    }
}
