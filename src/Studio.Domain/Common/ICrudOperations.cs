namespace Studio.Domain.Common;

public interface ICrudOperations<T> where T : BaseEntity
{
    Task<T> Create(T entity);
    Task<T> Read(Guid id);
    Task<T> Update(T entity);
    Task<T> Delete(Guid id);
}
