using ControllerLib_DotNetFramework.Interfaces.Logger;
using ControllerLib_DotNetFramework.Loger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class LogSaver<TOperType> : ILogSaver<TOperType>
        where TOperType : struct
    {
        public void Save(ILog<TOperType> log)
        {
            Console.WriteLine($"Saving {log}");
        }
    }
}
