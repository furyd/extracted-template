using FlexibleExample.Domain.Queries.Interfaces;
using FlexibleExample.Domain.Queries.Models;
using FlexibleExample.Domain.Repositories.Interfaces;

namespace FlexibleExample.Domain.Queries.Implementation
{
    public class DefaultExampleQueries : IExampleQueries
    {
        private readonly IExampleRepository _exampleRepository;

        public DefaultExampleQueries(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public ExampleModel ExampleQuery(int id) => Map(_exampleRepository.Retrieve(id));

        private static ExampleModel Map(Repositories.Models.ExampleModel model) =>
            new () { Id = model.Id, Value = model.Value };
    }
}