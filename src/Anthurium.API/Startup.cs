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
using Anthurium.API.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Anthurium.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
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
            services.AddCors();


            if (_env.IsProduction())
            {
                //services.AddDbContext<AnthuriumContext>(options => options
                //     .UseMySql("Server=localhost; Database=LightSailsErp;User=root;Password=;",
                //         mysqlOptions =>
                //             mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb))));


                //services.AddDbContext<AnthuriumContext>(options =>
                //options.UseInMemoryDatabase("LightSailsErp"));
                services.AddDbContext<AnthuriumContext>(options => options
               .UseMySql("Server=localhost; Database=LightSailsErp;User=root;Password=;persistsecurityinfo=true",
                   mysqlOptions =>
                       mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb))));
            }

            else
            {

                //services.AddDbContext<AnthuriumContext>(options =>
                //   options.UseInMemoryDatabase("LightSailsErp"));
                services.AddDbContext<AnthuriumContext>(options => options
               .UseMySql("Server=localhost; Database=LightSailsErp;User=root;Password=;persistsecurityinfo=true",
                   mysqlOptions =>
                       mysqlOptions.ServerVersion(new ServerVersion(new Version(10, 4, 6), ServerType.MariaDb))));
            }
          
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

            services.AddScoped<ISqlServerUserRepository, SqlServerUserRepository>();





            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddOdataSwaggerSupport();
            SetOutputFormatters(services);

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(x =>
                    {
                        x.Events = new JwtBearerEvents
                        {
                            OnTokenValidated = context =>
                            {
                                var userService = context.HttpContext.RequestServices.GetRequiredService<ISqlServerUserRepository>();
                                var userId = int.Parse(context.Principal.Identity.Name);
                                var user = userService.GetById(userId); 
                                if (user == null)
                                {
                                    // return unauthorized if user no longer exists
                                    context.Fail("Unauthorized");
                                }
                                return Task.CompletedTask;
                            }
                        };
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

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
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

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
