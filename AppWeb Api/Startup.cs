using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Domain.Repository;
using AppWeb_Api.BoundedPostulant.Domain.Service;
using AppWeb_Api.BoundedPostulant.Persistence.Repository;
using AppWeb_Api.BoundedPostulant.Services;
using AppWeb_Api.BoundedProject.Domain.Repository;
using AppWeb_Api.BoundedProject.Domain.Service;
using AppWeb_Api.BoundedProject.Persistence.Repository;
using AppWeb_Api.BoundedProject.Services;
using AppWeb_Api.BoundedCompany.Domain.Repository;
using AppWeb_Api.BoundedCompany.Domain.Service;
using AppWeb_Api.BoundedCompany.Persistence.Repository;
using AppWeb_Api.BoundedCompany.Resource;
using AppWeb_Api.BoundedCompany.Services;
using AppWeb_Api.BoundedAnnouncement.Domain.Repository;
using AppWeb_Api.BoundedAnnouncement.Domain.Service;
using AppWeb_Api.BoundedAnnouncement.Persistence.Repository;
using AppWeb_Api.BoundedAnnouncement.Services;
using AppWeb_Api.BoundedApplication.Domain.Repository;
using AppWeb_Api.BoundedApplication.Domain.Service;
using AppWeb_Api.BoundedApplication.Services;
using AppWeb_Api.BoundedApplication.Persistence.Repository;
using AppWeb_Api.BoundedNotification.Domain.Repository;
using AppWeb_Api.BoundedNotification.Domain.Service;
using AppWeb_Api.BoundedNotification.Services;
using AppWeb_Api.BoundedNotification.Persistence.Repository;
using AppWeb_Api.BoundedSecurity.Authorization.Handlers.Implementations;
using AppWeb_Api.BoundedSecurity.Authorization.Handlers.Interfaces;
using AppWeb_Api.BoundedSecurity.Authorization.Middleware;
using AppWeb_Api.BoundedSecurity.Authorization.Settings;
/*using AppWeb_Api.BoundedSecurity.Authorization.Handlers.Implementations;
using AppWeb_Api.BoundedSecurity.Authorization.Handlers.Interfaces;
using AppWeb_Api.BoundedSecurity.Authorization.Middleware;
using AppWeb_Api.BoundedSecurity.Authorization.Settings;
using AppWeb_Api.BoundedSecurity.Domain.Services;
using AppWeb_Api.BoundedSecurity.Services;*/
using AppWeb_Api.Common.Domain.Repositories;
using AppWeb_Api.Common.Persistence.Contexts;
using AppWeb_Api.Common.Persistence.Repositories;

namespace AppWeb_Api
{
    public class Startup
    {
        private readonly string _MyCors = "MyCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name:_MyCors, builder =>
                {
                    builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                        .AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo {Title = "AppWeb_Api", Version = "v1"}));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("appweb-api-in-memory");
            });
            services.AddScoped<IPostulantRepository, PostulantRepository>();
            services.AddScoped<IPostulantService, PostulantService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IEvidenceRepository, EvidenceRepository>();
            services.AddScoped<IEvidenceService, EvidenceService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<INotificationPostulantRepository, NotificationPostulantRepository>();
            services.AddScoped<INotificationPostulantService, NotificationPostulantService>();
            services.AddScoped<INotificationCompanyRepository, NotificationCompanyRepository>();
            services.AddScoped<INotificationCompanyService, NotificationCompanyService>();
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(_MyCors);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AppWeb_Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<JwtMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
