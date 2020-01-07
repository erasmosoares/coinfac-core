using CoinFac.Application.Accounts.Commands.CreateAccount;
using CoinFac.Application.Accounts.Commands.CreateAccount.Factory;
using CoinFac.Application.Accounts.Queries.GetAccountDetail;
using CoinFac.Application.Accounts.Queries.GetAccountsList;
using CoinFac.Application.Interfaces;
using CoinFac.Application.Interfaces.Services;
using CoinFac.Common.Dates;
using CoinFac.Common.Events.Details;
using CoinFac.Infrastructure.Message;
using CoinFac.Infrastructure.Network;
using CoinFac.Persistence;
using CoreEvents;
using CoreEvents.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoinFac.Presentation
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // 1. Add Authentication Services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://coinfac.auth0.com/";
                options.Audience = "https://api.coinfac.com";
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // Db Context
            services.AddDbContext<DatabaseService>(options => options.UseSqlServer(Configuration.GetConnectionString("CoinFacDb")));

            // Repository
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // CQRS Queries
            services.AddScoped<IGetAccountListQuery, GetAccountListQuery>();
            services.AddScoped<IGetAccountDetailQuery, GetAccountDetailQuery>();

            // Commands
            services.AddScoped<ICreateAccountFactory, CreateAccountFactory>();
            services.AddScoped<ICreateAccountCommand, CreateAccountCommand>();
            services.AddScoped<ICreateAccountFactory, CreateAccountFactory>();

            // External Services
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IDateService, DateService>();
            services.AddScoped<IWebClientWrapper, WebClientWrapper>();

            //MessagingCluster
            services.AddSingleton<IMessagingCluster, MessagingCluster>();

            //CoreEvents
            services.AddSingleton<ICoreEvents, CoreEvent>();

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // 2. Enable authentication middleware
            app.UseAuthentication();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
