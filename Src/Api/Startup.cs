using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kosku.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Kosku.Repositories;
using Microsoft.IdentityModel.Tokens;
using Kosku.Middleware;
using Kosku.Helpers;
using Microsoft.IdentityModel.Logging;

namespace Kosku
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string MyOrigin = "MyOrigin";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyOrigin, builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddScoped<IAnakKosRepository, AnakKosRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            var connectionString = Configuration.GetConnectionString("KoskuConnections");

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDbContext<AnakKosContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddControllers();

            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", options =>
               {
                   options.Authority = "https://localhost:5001";
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false
                   };
               });

            // adds an authorization policy to make sure the token is for scope 'api1'
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Kosku API",
                    Description = "Belajar REST API mengggunakan ASP.NET"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", name: "Kosku API");
            });

            app.UseRouting();

            app.UseCors(MyOrigin);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
