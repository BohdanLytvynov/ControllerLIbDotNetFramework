using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Interfaces.Controller
{
    public interface IController<TOperType>
        where TOperType : struct
    {
        #region Events

        event Action<IOperationResult<TOperType>> OnOperationCompleted;

        #endregion

        #region Methods

        IOperationResult<TOperType> Execute(TOperType operName,
            Func<object, dynamic> function, object p);

        void ExecuteAndGetResultViaEvent(TOperType operName,
            Func<object, dynamic> function, object p);

        Task<IOperationResult<TOperType>> ExecuteAsync(TOperType operName,
            Func<CancellationToken, object, dynamic> function, object p,
            CancellationToken token);

        #endregion
    }
}
