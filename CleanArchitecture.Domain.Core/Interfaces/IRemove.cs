namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IRemove<TEntity>
    {
        bool Remove(TEntity entity);
    }
}
