using FlexibleExample.Domain.Queries.Implementation;
using FlexibleExample.Domain.Queries.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlexibleExample.Domain.Queries.Registration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterQueries(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IExampleQueries, DefaultExampleQueries>();
        return serviceCollection;
    }
}