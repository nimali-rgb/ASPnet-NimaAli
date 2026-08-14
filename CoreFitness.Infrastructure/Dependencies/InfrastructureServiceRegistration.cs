using CoreFitness.Application.Interfaces;
using CoreFitness.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CoreFitness.Infrastructure.Dependencies;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
       
        services.AddScoped<IGymClassRepository, GymClassRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();

        return services;
    }
}
