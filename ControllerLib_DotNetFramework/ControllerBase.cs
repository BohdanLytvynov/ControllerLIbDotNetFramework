using ControllerLib_DotNetFramework.Enums;
using ControllerLib_DotNetFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework
{
    public class ControllerBase : IController
    {
        #region Events
        public event Action<IOperationResult> OperationCompleted;
        #endregion

        #region Fields

        #endregion

        #region Ctor
        public ControllerBase()
        {

        }
        #endregion

        #region Methods

        public async Task<IOperationResult> ExecuteAsync(string operName,
            Func<object, dynamic> function, object p)
        {
            IOperationResult result = null;

            await Task.Run(() =>
            {
                result = ExecuteAndTryToCatchException(operName,
                function, p);
            });

            return result;
        }

        public IOperationResult Execute(string operName, 
            Func<object, dynamic> function, object p)
        {
            return ExecuteAndTryToCatchException(operName,
            function, p);
        }

        public void ExecuteFunction(string operName,
            Func<object, dynamic> function, object p)
        {
            OperationCompleted?.Invoke(ExecuteAndTryToCatchException(operName,
            function, p));
        }

        #region Execution Envelope

        private IOperationResult ExecuteAndTryToCatchException(string operName,
            Func<object, dynamic> function, object p)
        {
            IOperationResult result;

            Exception ex = null;

            dynamic ExecutionResult = null;

            ExecutionState executionState = ExecutionState.ReadyForExceute;

            try
            {
                //Execute Operation

                ExecutionResult = function?.Invoke(p);

                executionState = ExecutionState.Finished;
            }
            catch (Exception e)
            {
                ex = e;

                executionState = ExecutionState.Failed;
            }
            finally
            {
                result = new OperationResult(operName, ex != null ? true : false,
                    ex, executionState)
                { Result = ExecutionResult };
            }

            return result;
        }
    }
}
