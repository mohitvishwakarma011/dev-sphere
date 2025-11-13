using DS.Core.Abstraction;

namespace DS.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public Task BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlRaw(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<int> ExecuteSqlRawAsync(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();

        }
    }
}
