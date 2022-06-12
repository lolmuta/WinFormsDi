using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTestTaskCancel
{
    internal static class SerilogInit
    {
        public static ILogger InitLog()
        {
            string outputTemplate =
                "{Timestamp:yyyy/MM/dd HH:mm:ss} " + // 2022/04/17 14:11:20
                        "[{Level:u5}] " +       //[INFOR]
                        "{SourceContext:l} " + //WinFormsApp1.Form1
                        "{Message:lj}" +        //123
                        "{NewLine}" +           //new line
                        "{Exception}";
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose() // 設定最低顯示層級   預設: Information
                .WriteTo.Console(
                    outputTemplate: outputTemplate
                ) // 輸出到 指令視窗
                .WriteTo.File("logs/log-.log",
                    rollingInterval: RollingInterval.Day, // 每天一個檔案
                    fileSizeLimitBytes: 1073741824L,   //1 file max size is  1gb
                    rollOnFileSizeLimit: true,           //if file is maxsize, will new filename
                    retainedFileCountLimit: 30,          //only keep 30 file log
                                                         //2022/04/17 14:11:20 [INFOR] WinFormsApp1.Form1 123
                    outputTemplate: outputTemplate
                ) // 輸出到檔案 檔名範例: log-20211005.log
                .CreateLogger();
            return Log.Logger;
        }
    }
}
