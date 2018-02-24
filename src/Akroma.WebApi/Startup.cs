using System;
using System.IO;
using System.Linq;
using Akroma.Domain.Addressess.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Brickweave.Cqrs.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Akroma.Domain.Blocks.Services;
using Akroma.Domain.Transactions.Services;
using Akroma.Persistence.SQL;
using Akroma.Persistence.SQL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Akroma.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
         
        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AkromaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AkromaConnectionString"),
                    x => x.MigrationsAssembly("Akroma.Persistence.SQL")));
            services.AddTransient<IBlocksRepository, SQLBlocksRepository>();
            services.AddTransient<IAddressRepository, SQLAddressRepository>();
            services.AddTransient<ITransactionsRepository, SQLTransactionsRepository>();

            services.AddCqrs(AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.StartsWith("Akroma"))
                .Where(a => a.FullName.Contains("Domain"))
                .ToArray()
            );
            services.AddCors();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Akroma API", Version = "v0.1.0" });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Akroma.WebApi.xml");
                c.IncludeXmlComments(filePath);
            });

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "docs";
                c.DocumentTitle("Akroma API");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Akroma API");
                c.InjectStylesheet("/flat.css");
            });

            app.UseStaticFiles();
            //app.UseCors(
            //    options => options.WithOrigins("http://example.com").AllowAnyMethod()
            //);
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseMvc();

            //TODO: move this to the deployment script (deploy.cmd on azure)
            //app.ApplicationServices.GetService<AkromaContext>().Database.Migrate();
        }
    }
}
