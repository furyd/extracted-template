namespace FlexibleExample.Domain.Repositories.Interfaces
{
    public interface ICreateRepository<in TModel>
    {
        void Create(TModel model);
    }
}