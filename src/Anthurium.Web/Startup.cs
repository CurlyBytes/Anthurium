using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityModel.Client;
using Blazored.SessionStorage;
using System.Reflection;
using AutoMapper;
using Anthurium.API.Profiles;
using Anthurium.Web.Services;
using Blazored.Toast;
using Blazored.Modal;
using Westwind.AspNetCore.LiveReload;
using Anthurium.Web.Models;
using Microsoft.Extensions.Options;

namespace Anthurium.Web
{
    public class Startup
    {

      

        public Startup(IConfiguration configuration
                        )
        {
            Configuration = configuration;
        
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<UtilitySettings>(Configuration.GetSection("APP_URL"));

            services.AddBlazoredToast();
            services.AddHttpClient<ClientInformationService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");

            })
                .AddClientAccessTokenHandler("web");

            services.AddHttpClient<JobOrderService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");

            })
                .AddClientAccessTokenHandler("web");


            services.AddHttpClient<JobOrderDescriptionOfWorkService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");

            })
                .AddClientAccessTokenHandler("web");

            services.AddHttpClient<DashboardService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");

            })
                .AddClientAccessTokenHandler("web");

            services.AddHttpClient<JobQuotationService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");

            })
                .AddClientAccessTokenHandler("web");

            services.AddHttpClient<JobQuotationDetailsDetails>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5001");

            })
                .AddClientAccessTokenHandler("web");


            services.AddAccessTokenManagement(options =>
            {
                options.Client.Clients.Add("web", new ClientCredentialsTokenRequest
                {
                    RequestUri = new Uri("http://localhost:5000/connect/token"),
                    ClientId = "anthurium-web",
                    ClientSecret = "thisismyclientspecificsecret"
                });
            });

            services.AddBlazoredSessionStorage();

            //services.AddSingleton<ApiTokenCacheService>();
            

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredModal();

            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new ClientInformationProfile());
                configuration.AddProfile(new JobOrderDescriptionOfWorkProfile());
                configuration.AddProfile(new JobOrderProfile());
                configuration.AddProfile(new JobQuotationDetailsProfile());
                configuration.AddProfile(new JobQuotationProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            services.AddLiveReload(config =>
            {
                config.LiveReloadEnabled = true;
                config.ClientFileExtensions = ".css,.js,.htm,.html";
                config.FolderToMonitor = "~/../";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseLiveReload();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}