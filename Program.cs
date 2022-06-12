using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTestTaskCancel.Forms;
using WinFormsTestTaskCancel.Services;
using WinFormsTestTaskCancel.Services.Contracts;

namespace WinFormsTestTaskCancel
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceCollection services = new ServiceCollection();
            //註冊各種服務類
            ConfigureServices(services);
            //取用所有form實體的物件 初始化
            FormFactory.Init(services.BuildServiceProvider());
            //主動從容器中獲取Form1
            var form1 = FormFactory.GetForm<Form1>();
            Application.Run(form1);
            //Application.Run(new Form1());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //註冊form
            AddForms(services);
            //註冊log
            AddLog(services);
            //註冊其它
            AddOthers(services);
        }
        /// <summary>
        /// 新的物件就寫在這一個方法內
        /// </summary>
        /// <param name="services"></param>
        private static void AddOthers(ServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
        }
        /// <summary>
        /// form註冊位置
        /// </summary>
        /// <param name="services"></param>
        private static void AddForms(ServiceCollection services)
        {
            services.AddScoped<Form1>();
            services.AddScoped<Form2>();
            //...
          
        }
        private static void AddLog(ServiceCollection services)
        {
            //Create logger instance
            var serilogLogger = SerilogInit.InitLog();
            //register logger
            services.AddLogging(builder =>
            {
                object p = builder.AddSerilog(logger: serilogLogger, dispose: true);
            });
        }
    }
}
