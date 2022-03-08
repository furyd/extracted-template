using FlexibleExample.Domain.Queries.Models;

namespace FlexibleExample.Domain.Queries.Interfaces
{
    public interface IExampleQueries
    {
        ExampleModel ExampleQuery(int id);
    }
}