﻿using ControllerLib_DotNetFramework.Enums;
using ControllerLib_DotNetFramework.Interfaces.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Loger
{
    public class Log : ILog
    {
        #region Properties

        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public string Operation { get; set; }
        public Exception Exception { get; set; }
        public ExecutionState ExecutionState { get; set; }
        public bool IsError { get; set; }

        #endregion

        #region Ctor
        public Log(Guid id, DateTime date, string operation,
            Exception ex, ExecutionState state)
        {
            Id = id;

            Date = date;

            Operation = operation;

            Exception = ex;

            ExecutionState = state;

            if (ex != null)            
                IsError = true;
            else
                IsError = false;
        }
        #endregion


    }
}