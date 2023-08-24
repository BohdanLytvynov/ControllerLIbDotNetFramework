using ControllerLib_DotNetFramework.Enums;
using ControllerLib_DotNetFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework
{
    public class OperationResult : IOperationResult
    {
        #region Properties
        public string Name { get; }
        public bool Success { get; }
        public Exception Exception { get; }
        public dynamic Result { get; set; }

        public ExecutionState ExecutionState { get; }

        #endregion

        #region Ctor
        public OperationResult(string name, bool success, Exception exception,
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
