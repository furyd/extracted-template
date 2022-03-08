using FlexibleExample.Domain.Repositories.Implementation;
using FlexibleExample.Domain.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlexibleExample.Domain.Repositories.Registration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IExampleRepository, DefaultExampleRepository>();
        return serviceCollection;
    }
}