using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using HelloWorldASPCore.Midleware;
using HelloWorldASPCore.Common.Models;
<<<<<<< HEAD
using HelloWorldASPCore.Common.Context;
=======
>>>>>>> ce3332a83d84906b9f8f23e4545d61b9a142e73f
using Microsoft.EntityFrameworkCore;

namespace HelloWorldASPCore
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<DataBaseMemory>(); // добавлено для хранения в памяти созданного объекта класса до конца работы контроллера
            var assemblyVersion = Assembly.GetAssembly(typeof(Startup)).GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "HelloWorldASPCore",
                        Description = "HelloWorldASPCore",
                        Version = "v" + assemblyVersion
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст MobileContext в качестве сервиса в приложение
<<<<<<< HEAD
            services.AddDbContext<DataBaseContext>(options =>
=======
            services.AddDbContext<UserContext>(options =>
>>>>>>> ce3332a83d84906b9f8f23e4545d61b9a142e73f
                options.UseSqlite(connection));
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            //app.UseHttpsRedirection();
            //Redirect for swagger 
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            app.UseMvc();
            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelloWorldASPCore V1");
            });            
        }
    }
}
