using Sistema.Application.Application.Evento;
using Sistema.Repository.Data;
using Sistema.Repository.Repositorys.Evento;
using Sistema.Repository.Repositorys.Geral;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linx.Infra.Data;
using Linx.Domain;
using Linx.Infra.Http.Seedwork.DependencyInjection;
using Linx.Application.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Linx.Infra.Http.Configurations;
using Microsoft.OpenApi.Models;

namespace SistemaGustavoAPI
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1" }); });

            services.AddScoped<IEventoService, EventoService>();

            //RegistrationBuilder.RegisterAll<IRepository, EventoRepository>(
            //   (service, implementation) => services.AddScoped(service, implementation));

            services.AddScoped<IGeralRepository, GeralRepository>();
            services.AddScoped<IEventosRepository, EventoRepository>();

            //RegistrationBuilder.RegisterAll<IAppService, EventoService>(
            //    (service, implementation) => services.AddScoped(service, implementation));
            
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(x=>x.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = String.Empty;
                c.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });
            //var optionsBuilder = new ApplicationBuilderOptions
            //{
            //    UseSwagger = true,
            //    Swagger = new ApplicationBuilderSwaggerOptions
            //    {
            //        EndpointName = "Swagger UI v1",
            //        RoutePrefix = string.Empty,
            //        Flow = "implicit",
            //        OAuthClientId = "swagger-oidc",
            //        OAuthAppName = "Swagger UI"
            //    },
            //    Cors = new ApplicationBuilderCorsOptions
            //    {
            //        Origins = Array.Empty<string>()
            //    }
            //};


            //if (optionsBuilder.UseSwagger)
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c =>
            //    {
            //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Gr V1");
            //        c.DisplayRequestDuration();
            //        c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            //        c.OAuthScopes(new string[] { "" });
            //    });
            //}

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
