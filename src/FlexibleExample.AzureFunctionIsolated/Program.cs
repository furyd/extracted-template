using Microsoft.Extensions.Hosting;
using FlexibleExample.Domain.Commands.Registration;
using FlexibleExample.Domain.Queries.Registration;
using FlexibleExample.Domain.Repositories.Registration;

namespace FlexibleExample.AzureFunctionIsolated;

public class Program
{
    public static void Main()
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.RegisterQueries();
                serviceCollection.RegisterCommands();
                serviceCollection.RegisterRepositories();
            })
            .Build();

        host.Run();
    }
}