using CleanAPI.Core.Interfaces;
using CleanAPI.Core.Services;
using CleanAPI.Infrastructure.Data;
using CleanAPI.Infrastructure.Filters;
using CleanAPI.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CleanAPI.API
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
                .ConfigureApiBehaviorOptions(options =>
                {
                    //options.SuppressModelStateInvalidFilter = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanAPI.API", Version = "v1" });
            });

            //DB Context
            services.AddDbContext<CleanAPIContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CleanAPI"));
            });

            //Resolve dependencies
            services.AddTransient<IPostService, PostService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            })
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanAPI.API v1"));
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
