using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OoptiRH.API.APIInfrastructure;
using OoptiRH.DBAcess.Implementations;
using OoptiRH.DBAcess.Interfaces;
using OoptiRH.Kernel.Logging;
using OoptiRH.Kernel.Mapping;
using OoptiRH.Kernel.SettingModels;
using OoptiRH.Manager.Implementations;
using OoptiRH.Manager.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace OoptiRH.Web
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IlogRepository, LogRepository>();
            services.AddScoped<OoptiRHExceptionAttribute>();
            services.AddScoped(typeof(IDBRepository<>), typeof(DBRepository<>));
            services.AddTransient<ICollaboratorManager, CollaboratorManager>();
            services.AddTransient<IJobManager, JobManager>();


            var MapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new OoptiRHMapperProfile()));
            var mapper = MapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            
            services.AddDbContext<OoptiRHContext>(
                options =>
                options.UseSqlServer(Configuration["OoptiRHSetting:DBConnection"]));

            services.Configure<OoptiRHSettings>(Configuration.GetSection("OoptiRHSetting"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["OoptiRHSetting:Application:Version"], new Info
                {
                    Version = Configuration["OoptiRHSetting:Application:Version"],
                    Title = Configuration["OoptiRHSetting:Application:Name"],
                    Description = Configuration["OoptiRHSetting:Application:Description"],
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration["OoptiRHSetting:Application:DocEndPoint"], Configuration["OoptiRHSetting:Application:Name"]);
            });
        }
    }
}
