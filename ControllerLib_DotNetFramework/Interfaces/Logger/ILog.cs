﻿using ControllerLib_DotNetFramework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Interfaces.Logger
{
    public interface ILog
    {
        #region Properties

        Guid Id { get; set; }

        DateTime Date { get; set; }

        string Operation { get; set; }

        Exception Exception { get; set; }

        ExecutionState ExecutionState { get; set; }

        bool IsError { get; set; }

        #endregion
    }
}
