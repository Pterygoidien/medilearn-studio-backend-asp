using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Studio.Application.Common.Interfaces;
using Studio.Infrastructure.Common.Persistence;
using Studio.Infrastructure.Courses.Persistence;

namespace Studio.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {

        return services.AddPersistence();
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services)
    {
        services.AddDbContext<StudioDbContext>(options =>
        {
            options.UseSqlite("Data Source = Studio.db");
        });

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IUnitOfWork>(
            serviceProvider => serviceProvider.GetRequiredService<StudioDbContext>()
        );

        return services;
    }
}