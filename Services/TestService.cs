using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsTestTaskCancel.Services.Contracts;

namespace WinFormsTestTaskCancel.Services
{
    internal class TestService : ITestService
    {
        public string GetIp()
        {
            return "GetIp xxx";
        }

        public string GetHelloWorld(string ipt)
        {
            return "Hello worid, you input is " + ipt;
        }
    }
}
