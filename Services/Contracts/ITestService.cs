using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestTaskCancel.Services.Contracts
{
    public interface ITestService
    {
        string GetHelloWorld(string ipt);
        string GetIp();
    }
}
