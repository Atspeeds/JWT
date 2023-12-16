using ClientManagement.Infrastrure.Configuration.IocConfig;
using FrameWorkUni.FW.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniVersityManagement.Infrastrure.Configuration.IocConfig;

namespace UniversityService.Api
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
            services.AddHttpContextAccessor();

            services.AddControllers();

            services.AddSingleton<AuthHelper>();

            var connectionString = Configuration.GetConnectionString("UniDb");
            UMConfig.Config(services, connectionString);
            CMConfig.Config(services,connectionString);




            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UniversityService.Api", Version = "v1" });
                //c.DocInclusionPredicate((doc, apiDescription) =>
                //{
                //    if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                //    var version = methodInfo.DeclaringType
                //        .GetCustomAttributes<ApiVersionAttribute>(true)
                //        .SelectMany(attr => attr.Versions);

                //    return version.Any(v => $"v{v.ToString()}" == doc);
                //});
            });








            services.AddAuthentication(Options =>
            {
                Options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(configureOptions =>
             {
                 configureOptions.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidIssuer = "Univer",
                     ValidAudience = "Univer",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("{041944FD-AC22-4A62-A590-D0FA79990A11}")),
                     ValidateIssuerSigningKey = true,
                     ValidateLifetime = true,
                 };
                 configureOptions.SaveToken = true; // HttpContext.GetTokenAsunc();
                 configureOptions.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         //log 
                         //........
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         //log
                         return Task.CompletedTask;
                     },
                     OnChallenge = context =>
                     {
                         return Task.CompletedTask;

                     },
                     OnMessageReceived = context =>
                     {
                         return Task.CompletedTask;

                     },
                     OnForbidden = context =>
                     {
                         return Task.CompletedTask;

                     }
                 };


             });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UniversityService.Api v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
