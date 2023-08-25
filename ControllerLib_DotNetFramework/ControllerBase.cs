using ControllerLib_DotNetFramework.Enums;
using ControllerLib_DotNetFramework.Interfaces.Controller;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework
{
    public class ControllerBase : IController
    {
        #region Events
        //Fires when operation finishes
        public event Action<IOperationResult> OnOperationCompleted;
        #endregion
        
        #region Ctor
        public ControllerBase()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Execute Function Async and get result via event OnOperationCompleted
        /// </summary>
        /// <param name="operName">Name of the operation</param>
        /// <param name="function">Delegate that holds method for execution</param>
        /// <param name="p">Parametrs for execution, represented using Object type</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        public async Task ExecuteAndGetResultViaEventAsync(string operName,
            Func<CancellationToken, object, dynamic> function, object p, 
            CancellationToken token)
        {
            IOperationResult result = null;

            await Task.Run(() =>
            {
                result = ExecuteAndTryToCatchExceptionForAsyncFunc(operName,
                function, token, p);
            });

            OnOperationCompleted?.Invoke(result);
        }
        /// <summary>
        /// Execute Function Async and get result
        /// </summary>
        /// <param name="operName">Name of the operation</param>
        /// <param name="function">Delegate that holds method for execution</param>
        /// <param name="p">Parametrs for execution, represented using Object type</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>IOperation result object that holds details of operation execution.</returns>
        public async Task<IOperationResult> ExecuteAsync(string operName,
            Func<CancellationToken, object, dynamic> function, object p,
            CancellationToken token)
        {
            IOperationResult result = null;

            await Task.Run(() =>
            {
                result = ExecuteAndTryToCatchExceptionForAsyncFunc(operName,
                function, token, p);
            });

            return result;
        }

        /// <summary>
        /// Execute Function Syncroniously and get the result
        /// </summary>
        /// <param name="operName">Name of the operation</param>
        /// <param name="function">Delegate that holds method for execution</param>
        /// <param name="p">Parametrs for execution, represented using Object type</param>
        /// <returns>IOperation result object that holds details of operation execution.</returns>
        public IOperationResult Execute(string operName, 
            Func<object, dynamic> function, object p)
        {
            return ExecuteAndTryToCatchException(operName,
            function, p);
        }
        /// <summary>
        /// Execute Function Syncroniously and get the result via event OnOperationFinished
        /// </summary>
        /// <param name="operName">Name of the operation</param>
        /// <param name="function">Delegate that holds method for execution</param>
        /// <param name="p">Parametrs for execution, represented using Object type</param>        
        public void ExecuteAndGetResultViaEvent(string operName,
            Func<object, dynamic> function, object p)
        {
            OnOperationCompleted?.Invoke(ExecuteAndTryToCatchException(operName,
            function, p));
        }

        #region Execution Envelope
        /// <summary>
        /// Execute Function and Catch Exception
        /// </summary>
        /// <param name="operName">Name of the operation</param>
        /// <param name="function">Delegate that holds method for execution</param>
        /// <param name="p"></param>
        /// <returns>Parametrs for execution, represented using Object type</returns>
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

        /// <summary>
        /// Execute Function and Catch Exception. Used for Async operations can catch 
        /// OperationCancelledException
        /// </summary>
        /// <param name="operName"></param>
        /// <param name="function"></param>
        /// <param name="token"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private IOperationResult ExecuteAndTryToCatchExceptionForAsyncFunc(string operName,
            Func<CancellationToken, object, dynamic> function, CancellationToken token,
            object p)
        {
            IOperationResult result;

            Exception ex = null;

            dynamic ExecutionResult = null;

            ExecutionState executionState = ExecutionState.ReadyForExceute;

            try
            {
                //Execute Operation

                ExecutionResult = function?.Invoke(token, p);

                executionState = ExecutionState.Finished;
            }
            catch (Exception e)
            {
                ex = e;

                executionState = ExecutionState.Failed;

                if (ex is OperationCanceledException)
                {
                    executionState = ExecutionState.Canceled;
                }
            }
            finally
            {
                result = new OperationResult(operName, ex != null ? true : false,
                    ex, executionState)
                { Result = ExecutionResult };
            }

            return result;
        }

        #endregion

        #endregion
    }
}
