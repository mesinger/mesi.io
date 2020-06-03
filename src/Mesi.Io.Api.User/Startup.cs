using Mesi.Io.Api.User.Data;
using Mesi.Io.Api.User.Domain;
using Mesi.Io.Api.User.MiddleWare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Mesi.Io.Api.User
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string DebugCorsPolicy = "DebugCorsPolicy";
        private readonly string ProductionCorsPolicy = "ProductionCorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: DebugCorsPolicy,
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
                
                options.AddPolicy(ProductionCorsPolicy, builder => builder.WithOrigins("https://mesi.io").WithMethods("GET", "POST").AllowAnyHeader());
            });
            
            services.AddControllers();

            services.Configure<UserMongoDbSettings>(Configuration.GetSection(nameof(UserMongoDbSettings)));
            services.AddSingleton<IUserMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<UserMongoDbSettings>>().Value);

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IPasswordHasher, DummyPasswordHasher>();
            services.AddSingleton<IUserRepository, MongoUserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // app.UseHttpsRedirection();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors(DebugCorsPolicy);
            }
            else
            {
                app.UseCors(ProductionCorsPolicy);
            }

            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseMiddleware(typeof(ExceptionHandlingMiddleWareDev));
            }
            else
            {
                app.UseMiddleware(typeof(ExceptionHandlingMiddleWare));
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/heartbeat", async context => { await context.Response.WriteAsync("heartbeat"); });
            });
        }
    }
}