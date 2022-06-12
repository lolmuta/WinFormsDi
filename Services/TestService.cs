using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WinFormsTestTaskCancel.Services.Contracts;

namespace WinFormsTestTaskCancel.Services
{
    internal class TestService : ITestService
    {
        private readonly ILogger _logger;

        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        public string GetIp()
        {
            return "GetIp xxx";
        }

        public string GetHelloWorld(string ipt)
        {
            return "Hello worid, you input is " + ipt;
        }

        public async Task<CancellationTokenSource> DoZoomIn()
        {
            var ZoomTaskCancel = new CancellationTokenSource(); ;
            var ct = ZoomTaskCancel.Token;
            Task ZoomTask = Task.Run(async () =>
            {
                while (true)
                {
                    await ZoomIn();
                    await Task.Delay(1000);
                    if (ct.IsCancellationRequested)
                    {
                        await ZoomStop();
                        break;
                    }
                }
            });
            return ZoomTaskCancel;
        }

        private async Task ZoomStop()
        {
            Task ZoomTask = Task.Run(async () =>
            {
                _logger.LogInformation("ZoomStop 開始");
                await Task.Delay(1000);
                _logger.LogInformation("ZoomStop 結束");
            });
        }

        private async Task ZoomIn()
        {
            Task ZoomTask = Task.Run(async () =>
            {
                _logger.LogInformation("ZoomIn 開始");
                await Task.Delay(1000);
                _logger.LogInformation("ZoomIn 結束");
            });
        }
    }
}
