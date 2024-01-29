namespace Studio.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}
