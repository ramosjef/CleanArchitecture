namespace CleanArchitecture.Domain.Core.Interfaces
{
    public interface IUpdate<TEntity> where TEntity : class
    {
        bool Update(TEntity entity);
    }
}
