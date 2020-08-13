using Kitpymes.Core.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tests.Api
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
            services.AddControllers();

            //**Opci�n 1: configuraci�n desde el appsetings**//
            services.LoadLogger(Configuration);

            //**Opci�n 2: configuraci�n manual**//
            //services.LoadLogger(loggers =>
            //{
            //    loggers.UseSerilog(serilog =>
            //    {
            //        serilog
            //            .AddConsole
            //            (
                        
            //            )
            //            .AddFile
            //            (
            //                minimumLevel: Kitpymes.Core.Logger.Abstractions.LoggerLevel.Info
            //            );
            //            //.AddEmail
            //            //(
            //            //    userName: "admin@app.com",
            //            //    password: "password",
            //            //    server: "smtp.gmail.com",
            //            //    from: "admin@app.com",
            //            //    to: "error@app.com"
            //            //);
            //    });
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
