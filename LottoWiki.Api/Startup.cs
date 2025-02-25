using LottoWiki.Api.Configurations;
using LottoWiki.Service.Workers;
using Microsoft.OpenApi.Models;

namespace LottoWiki.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            //services.AddScoped<LotoFacilWorkerSupplyBase>();
            //services.AddScoped<LotoFacilWorkerSupplyStatus>();
            //services.AddScoped<LotoFacilWorkerSupplyOverDue>();
            //services.AddScoped<LotoFacilWorkerSupplyDoOver>();
            services.AddSingleton<LotoFacilWorkerSupplyBase>();
            services.AddSingleton<LotoFacilWorkerSupplyStatus>();
            services.AddSingleton<LotoFacilWorkerSupplyOverDue>();
            services.AddSingleton<LotoFacilWorkerSupplyDoOver>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LottoLabAPI", Version = "v1" });
            });
            services.AddControllers();
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LottoLabAPI V1");
            });

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

//using LottoWiki.Api.Configurations;
//using LottoWiki.Service.Workers;
//using Microsoft.OpenApi.Models;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//namespace LottoWiki.Api
//{
//    public class Startup
//    {
//        public IConfiguration Configuration { get; }

//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            // Configuração de CORS
//            services.AddCors(options =>
//            {
//                options.AddPolicy("AllowAllOrigins",
//                    builder =>
//                    {
//                        builder.AllowAnyOrigin()
//                               .AllowAnyMethod()
//                               .AllowAnyHeader();
//                    });
//            });

//            // Registro dos Workers
//            services.AddScoped<LotoFacilWorkerSupplyBase>();
//            services.AddScoped<LotoFacilWorkerSupplyStatus>();
//            services.AddScoped<LotoFacilWorkerSupplyOverDue>();
//            services.AddScoped<LotoFacilWorkerSupplyDoOver>();

//            // Configuração do Swagger
//            services.AddEndpointsApiExplorer();
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LottoLabAPI", Version = "v1" });
//            });

//            // Adiciona suporte a Controllers na API
//            services.AddControllers();
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                app.UseHsts();
//            }

//            // Configuração do Swagger
//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LottoLabAPI V1");
//            });

//            // Middleware de tratamento de exceções personalizado
//            app.UseMiddleware<ExceptionMiddleware>();

//            // Configurações padrão do ASP.NET Core
//            app.UseHttpsRedirection();
//            app.UseStaticFiles();
//            app.UseRouting();
//            app.UseCors("AllowAllOrigins");
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//        }
//    }
//}