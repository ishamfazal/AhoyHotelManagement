using Ahoy.Hotel.Api.Services;
using Ahoy.Hotel.Core;
using Ahoy.Hotel.EntityFramework.Core;
using Ahoy.Hotel.Repository.Implementaion;
using Ahoy.Hotel.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Mime;

namespace Ahoy.Hotel.Api
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

            services.AddCors();
            services.AddHttpContextAccessor();
            //add exception filter and validation exception result
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                                                {
                                                    options.InvalidModelStateResponseFactory = context =>
                                                    {
                                                        var result = new BadRequestObjectResult(context.ModelState);
                                                        result.ContentTypes.Add(MediaTypeNames.Application.Json);
                                                        result.ContentTypes.Add(MediaTypeNames.Application.Xml);
                                                        return result;
                                                    };
                                                })
                .AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              );

            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            services.Configure<FormOptions>(options =>
            {
                // Set the limit to 256 MB
                options.MultipartBodyLengthLimit = 268435456;
            });

            //Dependency Injections
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<AhoyHotelContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(HotelConst.ConnectionStringName));
                options.EnableSensitiveDataLogging();
            });
            services.AddAutoMapper(typeof(AhoyAutoMapper));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ahoy Hotel API",
                    Description = "API mangement tool for Ahoy Hotel Management",
                });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials()); // allow credentials



            app.UseAuthentication();
            app.UseAuthorization();

            loggerFactory.AddFile("Logs/Ahoy-{Date}.txt");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ahoy Hotel Management API V1");
            });
        }
    }
}
