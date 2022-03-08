using FlexibleExample.Domain.Commands.Interfaces;
using FlexibleExample.Domain.Commands.Models;
using FlexibleExample.Domain.Repositories.Interfaces;

namespace FlexibleExample.Domain.Commands.Implementation
{
    public class DefaultExampleCommands : IExampleCommands
    {
        private readonly IExampleRepository _exampleRepository;

        public DefaultExampleCommands(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public void ExampleCommand(ExampleModel model) => _exampleRepository.Create(Map(model));

        private static Repositories.Models.ExampleModel Map(ExampleModel model) => new() { Value = model.Value };
    }
}