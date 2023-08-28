using ControllerLib_DotNetFramework.Enums;
using ControllerLib_DotNetFramework.Interfaces;
using ControllerLib_DotNetFramework.Interfaces.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework
{
    public class OperationResult<TOperName> : IOperationResult<TOperName>
        where TOperName : struct
    {
        #region Properties
        public TOperName Name { get; }
        public bool Success { get; }
        public Exception Exception { get; }
        public dynamic Result { get; set; }

        public ExecutionState ExecutionState { get; }

        #endregion

        #region Ctor
        public OperationResult(TOperName name, bool success, Exception exception,
            ExecutionState state)
        {
            Name = name;

            Success = success;

            Exception = exception;

            ExecutionState = state;
        }
        #endregion



    }
}
