using System.Text;
using Mesi.Io.Api.Clipboard.Data;
using Mesi.Io.Api.Clipboard.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Mesi.Io.Api.Clipboard
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
            
            services.AddAuthentication(cfg =>
                {
                    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = "mesi.io",
                        ValidateIssuer = true,
                        ValidAudience = "default.mesi.io",
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1"))
                    };
                });
            
            services.AddControllers();
            
            services.Configure<ClipboardMongoDbSettings>(Configuration.GetSection(nameof(ClipboardMongoDbSettings)));
            services.AddSingleton<IClipboardMongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<ClipboardMongoDbSettings>>().Value);

            services.AddSingleton<IClipboardRepository, MongoClipboardRepository>();
            services.AddSingleton<IClipboardService, ClipboardService>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/heartbeat", async context => { await context.Response.WriteAsync("heartbeat"); });
            });
        }
    }
}