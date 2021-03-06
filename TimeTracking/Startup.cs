using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Models;
using TimeTracking.Repositories;

using GraphQL;
using TimeTracking.GraphQL;
using GraphQL.Server;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using GraphQL.Server.Ui.Playground;


namespace TimeTracking
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
            
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(
                options => options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention()
            );

             //graphql dependency injection
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<TimetrackingSchema>();
            services.AddScoped<UserRepository>();
            services.AddScoped<ProjectRepository>();
            services.AddScoped<TeamRepository>();

            services.AddGraphQL(options => { options.ExposeExceptions = true; })
                    .AddGraphTypes(ServiceLifetime.Scoped);


            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => {
               builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            }));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseGraphQL<TimetrackingSchema>();
            //app.UseGraphQLPlayground(new GraphQLPlaygroundOptions{
                //Path = "/ui/playground"
            //});

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
