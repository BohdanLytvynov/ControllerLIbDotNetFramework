using ControllerLib_DotNetFramework.Enums;
using ControllerLib_DotNetFramework.Interfaces.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Loger
{
    public class Log<TOperType> : ILog<TOperType>
        where TOperType : struct
    {
        #region Properties

        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public TOperType Operation { get; set; }
        public Exception Exception { get; set; }
        public ExecutionState ExecutionState { get; set; }
        public bool IsError { get; set; }

        #endregion

        #region Ctor
        public Log(Guid id, DateTime date, TOperType operation,
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

        #region Methods

        public override string ToString()
        {
            string str = IsError == true? Exception.ToString() : String.Empty;

            return $"Date: {Date} | Operation: {Operation} | ExecutionState: {ExecutionState} | HasError: {IsError} \n\t{str}";
        }

        #endregion
    }
}
