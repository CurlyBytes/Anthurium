using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anthurium.API.Data;
using Anthurium.API.Repositories;
using Anthurium.API.Repositories.SqlServer;
using Anthurium.Shared.Models;
using Anthurium.Web.Repositories;
using Anthurium.Web.Repositories.SqlServer;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OData.Edm;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Microsoft.OpenApi.Models;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.Net.Http.Headers;
using OData.Swagger.Services;

namespace Anthurium.API
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddOData();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication("Bearer", options =>
            //    {
            //        options.Authority = "http://localhost:5000";
            //        options.RequireHttpsMetadata = false;
            //        options.ApiName = "anthurium-api";
            //    });

            services.AddAuthorization();

            //services.AddDbContext<AnthuriumContext>(options =>
            //    options.UseInMemoryDatabase("LightSailsErp"));

            services.AddDbContext<AnthuriumContext>(options => options
                 .UseMySql("Server=localhost; Database=LightSailsErp;User=root;Password=qwerty@123456;",
                     mysqlOptions =>
                         mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb))));
            services.AddDbContext<AnthuriumContext>(opt => opt.UseSqlServer
           (Configuration.GetConnectionString("AnthuriumConnection")));
            services.AddScoped<IClientInformation, SqlServerClientInformationRepository>();
            services.AddScoped<IJobOrderDescriptionOfWork, SqlServerJobOrderDescriptionOfWorkRepository>();
            services.AddScoped<IJobOrderRepository, SqlServerJobOrderRepository>();
            services.AddScoped<ISqlServerJobOrderQuotationDetails, SqlServerJobOrderQuotationDetails>();
            services.AddScoped<ISqlServerJobQuotationRepository, SqlServerJobQuotationRepository>();
            services.AddScoped<ISqlServerWarehouseRepository, SqlServerWarehouseRepository>();
            services.AddScoped<ISqlServerVendorRepository, SqlServerVendorRepository>();
            services.AddScoped<ISqlServerItemRepository, SqlServerItemRepository>();
            services.AddScoped<ISqlServerAssetRepository, SqlServerAssetRepository>();
            services.AddScoped<ISqlServerDeliveryReceiptRepository, SqlServerDeliveryReceiptRepository>();
            services.AddScoped<ISqlServerDeliveryReceiptDetailsRepository, SqlServerDeliveryReceiptDetailsRepository>();


            


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddOdataSwaggerSupport();
            SetOutputFormatters(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            IEdmModel model = EdmModelBuilder.Build();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().Expand().Count().MaxTop(50);
                endpoints.MapODataRoute("api", "api", model);
                
            });            
        }

        private static void SetOutputFormatters(IServiceCollection services)
        {
            services.AddMvcCore(options =>
            {
                IEnumerable<ODataOutputFormatter> outputFormatters =
                    options.OutputFormatters.OfType<ODataOutputFormatter>()
                        .Where(foramtter => foramtter.SupportedMediaTypes.Count == 0);

                foreach (var outputFormatter in outputFormatters)
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
                }
            });
        }
    }
}
