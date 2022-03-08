using FlexibleExample.Domain.Commands.Implementation;
using FlexibleExample.Domain.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlexibleExample.Domain.Commands.Registration;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection RegisterCommands(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IExampleCommands, DefaultExampleCommands>();
        return serviceCollection;
    }
}