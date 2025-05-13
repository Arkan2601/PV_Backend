using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using marcatel_api.Extensions;
using marcatel_api.Models;
using marcatel_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace marcatel_api
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
            var key = "BusinessCaseMarcatelApiV2Tibs!*";

            services.Configure<MarcatelDatabaseSetting>(Configuration.GetSection(nameof(MarcatelDatabaseSetting)));

            // Registering services
            services.AddSingleton<IMarcatelDatabaseSetting>(sp =>
                sp.GetRequiredService<IOptions<MarcatelDatabaseSetting>>().Value);

            services.AddSingleton<PersonasService>();
            services.AddSingleton<UsuariosService>();
            services.AddSingleton<EstadosService>();
            services.AddSingleton<ArticulosService>();
            services.AddSingleton<ModuloService>();
            services.AddSingleton<SucursalesService>();
            services.AddSingleton<CatModuloService>();
            services.AddSingleton<DetalleOrdenCompraService>();
            services.AddSingleton<ProveedoresService>();
            services.AddSingleton<InsumosService>();
            services.AddSingleton<EntradasService>();
            services.AddSingleton<DetalleEntradaService>();
            services.AddSingleton<BancosService>();
            services.AddSingleton<RecetasService>();

            services.AddSingleton<DetalleRecetaService>();

            services.AddSingleton<DetalleTraspasoService>();
            services.AddSingleton<ImagenService>();
            services.AddSingleton<DetalleRecetaService>();
            services.AddSingleton<TraspasosService>();

            services.AddSingleton<DetalleMovimientosService>();
            services.AddSingleton<OrdenCompraService>();



                       services.AddSingleton<DetalleRolService>();



            services.AddSingleton<DetalleRecetaService>();

            services.AddSingleton<MovimientosService>();
            services.AddSingleton<UnidadMedidaService>();
            services.AddSingleton<TraspasosService>();
            services.AddSingleton<ExistenciasService>();
            services.AddSingleton<ReportKardexMovService>();
            services.AddSingleton<LoginService>();



              services.AddSingleton<TipoMovimientoService>();
              services.AddSingleton<RolService>();
              services.AddSingleton<DetalleUsuariosService>();

                  services.AddSingleton<CfgColaboradoresService>();
                  services.AddSingleton<CfgPersonasTService>();
                   services.AddSingleton<CfgPuestosService>();

                  services.AddSingleton<CfgDepartamentosService>();

            services.AddCors();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.UseMemberCasing())
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = "https://marcatelapi.herokuapp.com/",
                    ValidAudience = "https://marcatelapi.herokuapp.com/",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            services.AddAuthorization();
            services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Swagger Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "ERP API",
                    Description = "ASP.NET Core Web API for ERP API.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "DEV",
                        Email = string.Empty,
                        Url = new Uri("https://www.utl.edu.mx/"),
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "License type",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                c.EnableAnnotations(); // Enable Swagger Annotations
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Template API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

