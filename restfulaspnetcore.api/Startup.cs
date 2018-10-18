using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using restfulaspnetcore.api.Infrastructure.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace restfulaspnetcore.api
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
            services.AddDbContext<ContextoAplicacao>(options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //ADD API VERSIONING
            services
                .AddMvcCore()
                .AddVersionedApiExplorer(options => {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddApiVersioning(options => options.ReportApiVersions = true);
            //ADDING SWAGGER SUPPORT
            services.AddSwaggerGen(options => {
                // //ADD BASE INFORMATION
                // options.SwaggerDoc("v1", new Info { Title = "Minha API", Version = "v1" });
                var _provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var _description in _provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(_description.GroupName, CreateInfoForApiVersion(_description));
                }
                options.OperationFilter<SwaggerDefaultValues>();
                //INTEGRATE XML DOCUMENTATION
                var _xmlDocFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(_xmlDocFileName);
            });
        }

        private Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var _version = description.ApiVersion.ToString(); 
            var _info = new Info {
                Title = "Minha API de Livros",
                Version = _version,
                Description = $"Descrição da API versão {_version}"
            };
            if (description.IsDeprecated) {
                _info.Description += "\nCUIDADO! Essa versão foi descontinuada";
            }
            return _info;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                // options.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome API");
                options.RoutePrefix = string.Empty;
                // build a swagger endpoint for each discovered API version
                foreach ( var description in provider.ApiVersionDescriptions )
                {
                    options.SwaggerEndpoint( $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant() );
                }
            });
            app.UseMvc();
        }
    }
}
