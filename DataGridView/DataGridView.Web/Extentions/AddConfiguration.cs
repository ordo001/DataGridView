using DataGridView.Context;
using DataGridView.Repositories;
using DataGridView.Repositories.Contracts;
using DataGridView.Services;
using DataGridView.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DataGridView.Web.Extentions;

/// <summary>
/// Класс конфигураций
/// </summary>
public static class AddConfiguration
{
    /// <summary>
    /// Сконфигурировать сервисы
    /// </summary>
    public static IServiceCollection ConfigureServices(this IServiceCollection services, ConfigurationManager configuration)
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

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog(loggerConf);
        });

        services.AddSingleton(loggerFactory);
        
        services.AddDbContext<StudentContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("StudentDb")));
        
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IStorage, StudentRepository>();
        
        return services;
    }
}