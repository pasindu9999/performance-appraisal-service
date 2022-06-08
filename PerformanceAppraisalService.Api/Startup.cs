using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PerformanceAppraisalService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceAppraisalService.Application.Interfaces;
using PerformanceAppraisalService.Application.Services;
using PerformanceAppraisalService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PerformanceAppraisalService.Application.Dtos;

namespace PerformanceAppraisalService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Inject Appsettings
            /*services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));*/
            var applicationSettings = Configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(applicationSettings);

            var blobstoragekey = Configuration.GetSection("AzureBlobConfigurations");
            services.Configure<AzureBlobConfiguratuions>(blobstoragekey);

            var appSettingsSecretKey = applicationSettings.Get<ApplicationSettings>();


            //Register AppSettings
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );
            
            //Register Services
            services.AddTransient<IOrganizationService, OrganizationService>();

            services.AddTransient<IAccountService, AccountService>();

            services.AddTransient<IUserProfileService, UserProfileService>();

            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IDesignationService, DesignationService>();
            services.AddTransient<ISalaryService, SalaryService>();
            services.AddTransient<IAzureBlobService, AzureBlobService>();
            services.AddTransient<IReviweeService, ReviweeService>();
            services.AddTransient<IReviwerService, ReviwerService>();
            services.AddTransient<IPanelService, PanelService>();
            services.AddTransient<IPanelReviwerService, PanelReviwerService>();            
            services.AddCors();

            services.AddControllers();

            //Jwt Authentication

            var key = Encoding.UTF8.GetBytes(appSettingsSecretKey.JWT_Secret);

            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
