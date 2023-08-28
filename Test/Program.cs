using ControllerLib_DotNetFramework;
using ControllerLib_DotNetFramework.Interfaces;
using ControllerLib_DotNetFramework.Interfaces.Controller;
using ControllerLib_DotNetFramework.Interfaces.Logger;
using ControllerLib_DotNetFramework.Loger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    internal enum Operation { CountAsync = 0, CountAsyncReverse }


    internal class Program
    {
        static ILogger<Operation> logger = new Logger<Operation>();

        static LogSaver<Operation> logSaver = new LogSaver<Operation>();

        static void Main(string[] args)
        {
            Console.WriteLine("Test");

            //Test Sync execution

            ControllerBase<Operation> controller = new ControllerBase<Operation>();

            //IOperationResult r = controller.Execute("TestFunc", (a) =>
            //{
            //    Console.WriteLine("Executing");

            //    return 2 + 2;
            //}, null);

            //Console.WriteLine(r.Result);

            controller.OnOperationCompleted += Controller_OperationCompleted;

            //controller.ExecuteAndGetResultViaEvent("TestFuncViaEvent",
            //    (a)=>
            //    {
            //        Console.WriteLine("Executing");

            //        return 5 * 2;
            //    }, null);

            CancellationTokenSource cts1 = new CancellationTokenSource();

            CancellationTokenSource cts2 = new CancellationTokenSource();

            var r = controller.ExecuteAndGetResultViaEventAsync(Operation.CountAsync, 
                (ctst,a)=>
                {
                    int sum = 0;

                    for (int i = 0; i < 100000000; i++)
                    {
                        if (ctst.IsCancellationRequested)
                        {
                            ctst.ThrowIfCancellationRequested();
                        }                                                

                        sum += i;
                    }
                    
                    return sum;

                }, null, cts1.Token
                );

            //cts1.Cancel();

            var r1 = controller.ExecuteAndGetResultViaEventAsync(Operation.CountAsyncReverse,
                (ctst, a) =>
                {
                    int sum = 0;

                    for (int i = 100; i > 0; i--)
                    {
                        if (i == 55)
                        {
                            throw new NullReferenceException("Ooops! Smth gone wrong!");
                        }

                        if (ctst.IsCancellationRequested)
                        {
                            ctst.ThrowIfCancellationRequested();
                        }                        
                        
                        sum += i;
                    }

                    return sum;

                }, null, cts2.Token
                );
            
            Console.WriteLine("Finish");

            Console.ReadKey();
        }

        private static void Controller_OperationCompleted(IOperationResult<Operation> obj)
        {
            Console.WriteLine($"{obj.Name} Result: {obj.Result}");

            logger.SaveLog(logger.Create(obj), logSaver);
        }
    }
}
