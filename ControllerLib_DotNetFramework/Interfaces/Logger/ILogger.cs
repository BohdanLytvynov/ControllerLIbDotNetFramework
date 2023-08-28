using ControllerLib_DotNetFramework.Interfaces.Controller;
using ControllerLib_DotNetFramework.Loger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Interfaces.Logger
{
    public interface ILogger<TOperType>
        where TOperType : struct
    {
        ILog<TOperType> Create(IOperationResult<TOperType> result);

        void SaveLogToCollection(IOperationResult<TOperType> result ,IEnumerable<ILog<TOperType>> logs);

        void SaveLog(ILog<TOperType> log, ILogSaver<TOperType> saver);
    }
}
