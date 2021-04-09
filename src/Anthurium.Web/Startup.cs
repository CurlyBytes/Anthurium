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
using BlazorDownloadFile;
using System.Net.Http;

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

            //services.Configure<UtilitySettings>(Configuration.GetSection("APP_URL"));
            //ervices.Configure<UtilitySettings>("http://localhost:5001");

            services.AddBlazoredToast();
        
            services.AddScoped(x => {
                var apiUrl = new Uri("http://localhost:5001");

                // use fake backend if "fakeBackend" is "true" in appsettings.json

                return new HttpClient() { BaseAddress = apiUrl };
            });
            services.AddBlazorDownloadFile();

            //services.AddAccessTokenManagement(options =>
            //{
            //    options.Client.Clients.Add("web", new ClientCredentialsTokenRequest
            //    {
            //        RequestUri = new Uri("http://localhost:5000/connect/token"),
            //        ClientId = "anthurium-web",
            //        ClientSecret = "thisismyclientspecificsecret"
            //    });
            //});

            services.AddBlazoredSessionStorage();

            //services.AddSingleton<ApiTokenCacheService>();

            services.AddScoped<IAccountService, AccountService>()
                .AddScoped<IClientInformationService, ClientInformationService>()
                .AddScoped<IJobOrderService, JobOrderService>()
                .AddScoped<IJobOrderDescriptionOfWorkService, JobOrderDescriptionOfWorkService>()
                .AddScoped<IDashboardService, DashboardService>()
                .AddScoped<IJobQuotationService, JobQuotationService>()
                .AddScoped<IJobQuotationDetailsDetails, JobQuotationDetailsDetails>()
                .AddScoped<IWarehouseService, WarehouseService>()
                .AddScoped<IVendorService, VendorService>()
                .AddScoped<IItemService, ItemService>()
                .AddScoped<IAssetService, AssetService>()
                .AddScoped<IDeliveryReceiptService, DeliveryReceiptService>()
                .AddScoped<IAlertService, AlertService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();
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
                configuration.AddProfile(new WarehouseProfiles());
                configuration.AddProfile(new ItemProfile());
                configuration.AddProfile(new AssetProfile());
                configuration.AddProfile(new DeliveryReceiptDetailsProfiles());
                configuration.AddProfile(new DeliveryRecieptProfile());
                configuration.AddProfile(new VendorProfile());
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            //services.AddLiveReload(config =>
            //{
            //    config.LiveReloadEnabled = true;
            //    config.ClientFileExtensions = ".css,.js,.htm,.html";
            //    config.FolderToMonitor = "~/../";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              //  app.UseLiveReload();
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
