using System.Text.Json;
using System.Threading.Tasks;
using FlexibleExample.AzureFunction.Constants;
using FlexibleExample.Domain.Commands.Interfaces;
using FlexibleExample.Domain.Commands.Models;
using FlexibleExample.Domain.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace FlexibleExample.AzureFunction;

public class ExampleFunction
{
    private readonly IExampleQueries _exampleQueries;
    private readonly IExampleCommands _exampleCommands;

    public ExampleFunction(IExampleQueries exampleQueries, IExampleCommands exampleCommands)
    {
        _exampleQueries = exampleQueries;
        _exampleCommands = exampleCommands;
    }

    [FunctionName($"{Routes.Example}_{nameof(RetrieveById)}")]
    public IActionResult RetrieveById([HttpTrigger(AuthorizationLevel.Function, Verbs.Get, Route = Routes.Example + "/{id:int}")] HttpRequest req, int id)
    {
        return new OkObjectResult(_exampleQueries.ExampleQuery(id));
    }

    [FunctionName($"{Routes.Example}_{nameof(Create)}")]
    public async Task<IActionResult> Create([HttpTrigger(AuthorizationLevel.Function, Verbs.Post, Route = Routes.Example + "/")] HttpRequest req)
    {
        var model = await JsonSerializer.DeserializeAsync<ExampleModel>(req.Body);
        _exampleCommands.ExampleCommand(model);
        return new AcceptedResult();
    }
}