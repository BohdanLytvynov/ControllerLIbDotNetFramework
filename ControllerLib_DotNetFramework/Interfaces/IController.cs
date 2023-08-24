using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib_DotNetFramework.Interfaces
{
    public interface IController
    {
        #region Events

        event Action<IOperationResult> OperationCompleted;

        #endregion

        #region Methods

        IOperationResult Execute(string operName,
            Func<object, dynamic> function, object p);

        void ExecuteFunction(string operName,
            Func<object, dynamic> function, object p);

        Task<IOperationResult> ExecuteAsync(string operName,
            Func<object, dynamic> function, object p);

        #endregion
    }
}
