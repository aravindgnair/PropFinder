using Microsoft.Extensions.DependencyInjection;
using PropFinder.Application.Interfaces;
using PropFinder.Application.Services;
using PropFinder.Infrastructure.Persistence.Repositories;

namespace PropFinder.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<ISpaceRepository, SpaceRepository>();

        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<ISpaceService, SpaceService>();

        return services;
    }
}
