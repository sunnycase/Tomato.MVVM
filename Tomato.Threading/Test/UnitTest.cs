using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Tomato.Threading;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly OperationQueue _operationQueue = new OperationQueue(1);

        [TestMethod]
        public async Task TestMethod1()
        {
            await _operationQueue.Queue(async () =>
            {
                await Task.Delay(1000);
                Math.Abs(234);
                await Task.Delay(1000);
                Math.Abs(234);
                await Task.Delay(1000);
                Math.Abs(234);
                await Task.Delay(1000);
                Math.Abs(234);
                await Task.Delay(1000);
            });
        }
    }
}
