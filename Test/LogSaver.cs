using ControllerLib_DotNetFramework.Interfaces.Logger;
using ControllerLib_DotNetFramework.Loger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class LogSaver : ILogSaver
    {
        public void Save(ILog log)
        {
            Console.WriteLine($"Saving {log}");
        }
    }
}
