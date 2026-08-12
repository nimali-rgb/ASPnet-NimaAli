using CoreFitness.Application.Interfaces;
using CoreFitness.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFitness.Application.Dependencies;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMembershipService, MembershipService>();
        services.AddScoped<IGymClassService, GymClassService>();
        services.AddScoped<IBookingService, BookingService>();

        return services;
    }
}
