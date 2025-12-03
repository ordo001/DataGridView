using DataGridView.Services;
using DataGridViewProject.Forms;
using Microsoft.Extensions.Logging;
using Serilog;

namespace DataGridViewProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var loggerConf = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .WriteTo.File("logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.Seq("http://localhost:5341",
                    apiKey: "4MgpCqqUic7t4CKsyFYK")
                .CreateLogger();

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(loggerConf);
            });
            
            
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new StudentService(new InMemoryStorage(), loggerFactory)));
        }
    }
}