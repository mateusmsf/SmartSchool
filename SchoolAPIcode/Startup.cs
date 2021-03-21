using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using SchoolAPIcode.Data;

namespace SchoolAPIcode
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

            services.AddDbContext<SmartContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            services.AddControllers();

            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("SmartSchoolApi", 
                             new Microsoft.OpenApi.Models.OpenApiInfo() 
                                { 
                                    Title = "SmartSchool Api", 
                                    Version = "1.0"
                                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger().
                    UseSwaggerUI(c => {
                        c.SwaggerEndpoint("/swagger/SmartSchoolApi/swagger.json", "SmartSchool");
                        c.RoutePrefix = "";
                    });
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
