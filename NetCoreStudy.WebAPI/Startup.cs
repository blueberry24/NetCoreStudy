using Autofac;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreStudy.Infrastructure.Repositories;
using NetCoreStudy.WebAPIProject.Extensions;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;

namespace NetCoreStudy.WebAPIProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss}]{Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
                .WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "Api1={0:yyyy-MM-dd}",
                })
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddControllersAsServices()
                .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
                //.AddJsonOptions(options=>options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddMySqlDoaminContext("server=localhost;port=3306;database=NetCoreStudyDB;user=root;password=admin12345;");
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential();// 该扩展在每次启动时，为令牌签名创建一个临时密钥

            services.AddCors(option =>
            {
                option.AddPolicy("DefaultPolicy",
                    policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //services.AddScoped<ISubjectRepository, SubjectRepository>();
            //services.AddScoped<IExaminationRepository, ExaminationRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    // AutoMapper
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); // MediatR
            services.AddMediatRServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseIdentityServer();

            app.UseCors("DefaultPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //在这里添加服务注册
            //builder.RegisterType<SubjectRepository>();
            //builder.RegisterType<ExaminationRepository>();

            //批量注册
            //var controllerBaseType = typeof(ControllerBase);
            //builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            //    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            //    .PropertiesAutowired();

            //批量注册2 
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(s => s.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

    }
}
