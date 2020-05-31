using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoinFac.Persistence.Repositories.Accounts;
using CoinFac.Application.Interfaces.Repositories;
using CoinFac.Persistence;
using Microsoft.EntityFrameworkCore;
using CoinFac.Application.Interfaces;
using AutoMapper;
using Microsoft.OpenApi.Models;

namespace CoinFac.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<DatabaseService>(options => options.UseSqlServer(Configuration.GetConnectionString("CoinFacDb")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddCors(); 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "CoinFac API",
                    Description = "This is the first CoinFac API specification",
                    Version = "v1" 
                });
            });
        }

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

            string[] origins = new string[]             { 
                "https://localhost:44372", 
                "https://localhost:44342",
                "https://localhost:44372/api/user",
                "https://localhost:44372/api/accounts"
            }; 

            app.UseCors(b => b.AllowAnyMethod().AllowAnyHeader().WithOrigins(origins));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoinFac API V1");
            });

            app.UseMvc();

            
        }
    }
}
