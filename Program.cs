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
            //���U�U�تA����
            ConfigureServices(services);
            //���ΩҦ�form���骺���� ��l��
            FormFactory.Init(services.BuildServiceProvider());
            //�D�ʱq�e�������Form1
            var form1 = FormFactory.GetForm<Form1>();
            Application.Run(form1);
            //Application.Run(new Form1());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //���Uform
            AddForms(services);
            //���Ulog
            AddLog(services);
            //���U�䥦
            AddOthers(services);
        }
        /// <summary>
        /// �s������N�g�b�o�@�Ӥ�k��
        /// </summary>
        /// <param name="services"></param>
        private static void AddOthers(ServiceCollection services)
        {
            services.AddScoped<ITestService, TestService>();
        }
        /// <summary>
        /// form���U��m
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
