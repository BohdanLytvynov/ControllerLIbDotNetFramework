using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Enums
{
    public enum ExecutionState : byte
    { 
        Finished = 0, Canceled, Failed, ReadyForExceute
    }
}
