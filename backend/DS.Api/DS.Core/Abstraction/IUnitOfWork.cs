namespace DS.Core.Abstraction
{
    public interface IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void Commit();
        Task CommitAsync();
        void BeginTransaction();
        Task BeginTransactionAsync();
        void Rollback();
        Task RollbackAsync();
        int ExecuteSqlRaw(string sql, params object[] parameters);
        Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters);

    }
}
