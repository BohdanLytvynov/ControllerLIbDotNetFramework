using ControllerLib_DotNetFramework.Interfaces.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Loger
{
    public interface ILogSaver
    {
        void Save(IOperationResult result);
    }
}
