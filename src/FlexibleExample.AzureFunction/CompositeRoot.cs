using FlexibleExample.Domain.Commands.Registration;
using FlexibleExample.Domain.Queries.Registration;
using FlexibleExample.Domain.Repositories.Registration;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(FlexibleExample.AzureFunction.CompositeRoot))]
namespace FlexibleExample.AzureFunction;

public class CompositeRoot : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.RegisterCommands();
        builder.Services.RegisterQueries();
        builder.Services.RegisterRepositories();
    }
}