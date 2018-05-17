using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.Mvc.Controllers;

using Microsoft.Extensions.PlatformAbstractions;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

using Microsoft.EntityFrameworkCore;
using AuthApi.Models;

namespace AuthApi
{
    public class Startup
    {
        protected internal Info SwaggerApiDocInformation { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            SwaggerApiDocInformation = new Info
            {
                Title = "Authentication Api",
                Version = "V1",
                Description = "Help for Authentication for Burning Services",
                Contact = new Contact
                {
                    Name = "Burning River Softworks"
                }
            };

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TodoContext>(opts =>
                opts.UseInMemoryDatabase("TodoList"));

            services.AddMvc();

            /* Swagger 
                        services.AddSwaggerGen(options => 
                        {
                            options.SwaggerDoc($"{SwaggerApiDocInformation.Version.ToLowerInvariant()}", SwaggerApiDocInformation);
                            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                            var xmlPath = Path.Combine(basePath, "Authentication.Api.xml");
                            options.IncludeXmlComments(xmlPath);
                            options.TagActionsBy(apiDesc => $"{(apiDesc.ActionDescriptor as ControllerActionDescriptor).ControllerName} {apiDesc.HttpMethod}");
                        });*/


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /* Swagger 
            app.UseSwaggerUI(options => {

                options.InjectStylesheet("D:/Development/Burning/Authentication/src/AuthApi/wwwroot/api-docs/ui/custom-swagger.css");
            });
            app.UseSwagger(options => 
            {
                options.RouteTemplate = "swagger.json";
            });*/


            app.UseMvc();
        }
    }
}
