using ControllerLib_DotNetFramework.Interfaces.Controller;
using ControllerLib_DotNetFramework.Interfaces.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Loger
{
    public interface ILogSaver
    {
        /// <summary>
        /// Method that saves ILog object to some location (File or db)
        /// </summary>
        /// <param name="result">ILog object</param>
        void Save(ILog log);
    }
}
