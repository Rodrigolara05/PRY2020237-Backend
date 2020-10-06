using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Swashbuckle.AspNetCore.Swagger;
using PRY2020237.Repository;
using PRY2020237.RepositoRy.implementation;
using PRY2020237.Service;
using PRY2020237.Service.implementation;
using PRY2020237.Repository.Context;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace PRY2020237.Api
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
             services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUserRepository, UserRepository> ();
            services.AddTransient<IUserService, UserService> ();

            services.AddTransient<IProjectRepository, ProjectRepository> ();
            services.AddTransient<IProjectService, ProjectService> ();

            services.AddTransient<IPageViewRepository, PageViewRepository> ();
            services.AddTransient<IPageViewService, PageViewService> ();

            services.AddTransient<IComponentRepository, ComponentRepository> ();
            services.AddTransient<IComponentService, ComponentService> ();

            services.AddTransient<IComponentTypeRepository, ComponentTypeRepository> ();
            services.AddTransient<IComponentTypeService, ComponentTypeService> ();

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_3_0);//validar

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerConfiguration.DocInfoVersion, new OpenApiInfo
                {
                    Version = SwaggerConfiguration.DocInfoVersion,
                    Title = SwaggerConfiguration.DocInfoTitle,
                    Description = SwaggerConfiguration.DocInfoDescription,
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Cesar Gutierrez / Rodrigo Lara",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });

  
            services.AddCors(options =>
            {
                options.AddPolicy("Todos",
                builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });


        }

//https://localhost:5001/swagger/index.html


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
             app.UseCors("Todos");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
                    
        }
    }
}
