using Application.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace API5
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
            services.AddDbContext<ApplicationDbContext>(data =>
                data.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                SwaggerGenOptionsExtensions.SwaggerDoc(c, "v4.0.1", new Info { Title = "Core API", Description = "Swagger Core ApI" });

                //var xmlpass = System.AppDomain.CurrentDomain.BaseDirectory + @"API4.xml";
                //c.IncludeXmlComments(xmlpass);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseMvc();
            app.UseMvc();
            app.UseSwagger();
            if (app != null)
                // ReSharper disable once ConstantConditionalAccessQualifier
                app.UseSwaggerUI(delegate(SwaggerUIOptions c)
                {
                    c.SwaggerEndpoint("/swagger/v4.0.1/swagger.json", "Core API");
                });
        }
    }
}
