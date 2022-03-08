using Microsoft.AspNetCore.Mvc;
using System.Net;
using FlexibleExample.Domain.Commands.Interfaces;
using FlexibleExample.Domain.Queries.Interfaces;
using FlexibleExample.ServiceFabric.Api.Constants;

namespace FlexibleExample.ServiceFabric.Api.Controllers
{
    [ApiController]
    [Route(Routes.Example)]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    [Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleQueries _exampleQueries;
        private readonly IExampleCommands _exampleCommands;

        public ExampleController(IExampleQueries exampleQueries, IExampleCommands exampleCommands)
        {
            _exampleQueries = exampleQueries;
            _exampleCommands = exampleCommands;
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Domain.Queries.Models.ExampleModel), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public IActionResult ExampleGet(int id)
        {
            return Ok(_exampleQueries.ExampleQuery(id));
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public IActionResult ExamplePost([FromBody] Domain.Commands.Models.ExampleModel model)
        {
            _exampleCommands.ExampleCommand(model);
            return Accepted();
        }
    }
}
