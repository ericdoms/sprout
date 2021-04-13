using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SproutSolution.API.Middleware;
using SproutSolution.Repository.Interface;
using SproutSolution.Repository.Repository;
using SproutSolution.Service.Interface;
using SproutSolution.Service.Service;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace SproutSolution
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
            services.AddControllers();
            ConfigureDependency(services);

            services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationMiddleware>("BasicAuthentication", null);
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200/",
                                            "http://localhost:4200",
                                            "https://localhost:4200/",
                                            "localhost:4200",
                                            "https://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Name = "Basic",
                    Description = "Please enter your username and password",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Basic" }
                        }, new List<string>()
                    }
                });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sprout Solution API");
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureDependency(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
