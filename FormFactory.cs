using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestTaskCancel
{
    /// <summary>
    /// 取用所有form實體的物件
    /// </summary>
    public static class FormFactory
    {
        private static ServiceProvider _serviceProvider;
        public static void Init(ServiceProvider ServiceCollection)
        {
            _serviceProvider = ServiceCollection;
        }
        public static T GetForm<T>()
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
