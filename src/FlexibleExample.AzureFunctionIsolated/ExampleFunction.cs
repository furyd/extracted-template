using System.Net;
using System.Threading.Tasks;
using FlexibleExample.AzureFunctionIsolated.Constants;
using FlexibleExample.Domain.Commands.Interfaces;
using FlexibleExample.Domain.Commands.Models;
using FlexibleExample.Domain.Queries.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace FlexibleExample.AzureFunctionIsolated;

public class ExampleFunction
{
    private readonly IExampleQueries _exampleQueries;
    private readonly IExampleCommands _exampleCommands;

    public ExampleFunction(IExampleQueries exampleQueries, IExampleCommands exampleCommands)
    {
        _exampleQueries = exampleQueries;
        _exampleCommands = exampleCommands;
    }

    [Function($"{Routes.Example}_{nameof(RetrieveById)}")]
    public async Task<HttpResponseData> RetrieveById([HttpTrigger(AuthorizationLevel.Anonymous, Verbs.Get, Route = Routes.Example + "/{id:int}")] HttpRequestData req, int id)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(_exampleQueries.ExampleQuery(id));
        return response;
    }

    [Function($"{Routes.Example}_{nameof(Create)}")]
    public async Task<HttpResponseData> Create([HttpTrigger(AuthorizationLevel.Anonymous, Verbs.Post, Route = Routes.Example + "/")] HttpRequestData req)
    {
        var model = await req.ReadFromJsonAsync<ExampleModel>();
        _exampleCommands.ExampleCommand(model);
        
        var response = req.CreateResponse(HttpStatusCode.Accepted);
        return response;
    }
}