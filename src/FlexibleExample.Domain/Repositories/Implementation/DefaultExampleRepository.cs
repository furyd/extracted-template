using FlexibleExample.Domain.Repositories.Interfaces;
using FlexibleExample.Domain.Repositories.Models;

namespace FlexibleExample.Domain.Repositories.Implementation
{
    public class DefaultExampleRepository : IExampleRepository
    {
        public ExampleModel Retrieve(int key) => new() { Id = 1, Value = "Test" };

        public void Create(ExampleModel model)
        {
        }
    }
}