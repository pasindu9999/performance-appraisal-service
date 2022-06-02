using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Application.Processors.Email;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(PerformanceAppraisalService.EmailFunction.StartUp))]
namespace PerformanceAppraisalService.EmailFunction
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IRegistrationEmailProcessor, RegistrationEmailProcessor>();

            builder.Services.AddTransient<ILoginEmailProcessor, LoginEmailProcessor>();

            builder.Services.AddTransient<IConfirmEmailProcessor, ConfirmEmailProcessor>();

            string connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        }
    }
}
