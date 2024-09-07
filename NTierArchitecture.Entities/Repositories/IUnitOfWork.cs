namespace NTierArchitecture.Entities.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanegesAsync(CancellationToken cancellationToken = default);
    }
}
