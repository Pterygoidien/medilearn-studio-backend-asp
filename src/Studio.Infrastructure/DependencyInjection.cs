using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Studio.Application.Common.Interfaces;
using Studio.Infrastructure.Common.Persistence;
using Studio.Infrastructure.Courses.Persistence;

namespace Studio.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        return services.AddPersistence(configuration);
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddDbContext<StudioDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("StudioDb"));
        });

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IUnitOfWork>(
            serviceProvider => serviceProvider.GetRequiredService<StudioDbContext>()
        );

        return services;
    }
}