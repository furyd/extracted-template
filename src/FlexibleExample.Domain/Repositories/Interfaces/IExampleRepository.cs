using FlexibleExample.Domain.Repositories.Models;

namespace FlexibleExample.Domain.Repositories.Interfaces
{
    public interface IExampleRepository : IRetrieveRepository<ExampleModel, int>, ICreateRepository<ExampleModel>
    {
    }
}