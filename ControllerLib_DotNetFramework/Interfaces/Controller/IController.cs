using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Interfaces.Controller
{
    public interface IController
    {
        #region Events

        event Action<IOperationResult> OnOperationCompleted;

        #endregion

        #region Methods

        IOperationResult Execute(string operName,
            Func<object, dynamic> function, object p);

        void ExecuteAndGetResultViaEvent(string operName,
            Func<object, dynamic> function, object p);

        Task<IOperationResult> ExecuteAsync(string operName,
            Func<CancellationToken, object, dynamic> function, object p,
            CancellationToken token);

        #endregion
    }
}
