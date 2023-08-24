using ControllerLib_DotNetFramework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Interfaces
{
    public interface IOperationResult
    {
        #region Properties

        string Name { get;}

        bool Success { get;}

        Exception Exception { get;}

        dynamic Result { get; set; }

        ExecutionState ExecutionState { get; }

        #endregion
    }
}
