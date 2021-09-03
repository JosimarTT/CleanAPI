using CleanAPI.Core.CustomEntities;
using CleanAPI.Core.Interfaces.Repositories;
using CleanAPI.Core.Interfaces.Services;
using CleanAPI.Core.Services;
using CleanAPI.Infrastructure.Data;
using CleanAPI.Infrastructure.Interfaces;
using CleanAPI.Infrastructure.Options;
using CleanAPI.Infrastructure.Repositories;
using CleanAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAPI.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CleanAPIContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CleanAPI"));
            });
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PaginationOptions>(configuration.GetSection("Pagination"));
            services.Configure<PasswordOptions>(configuration.GetSection("PasswordOptions"));
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

