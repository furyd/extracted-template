namespace FlexibleExample.Domain.Repositories.Interfaces;

public interface IRetrieveRepository<out TModel, in TKey>
{
    TModel Retrieve(TKey key);
}