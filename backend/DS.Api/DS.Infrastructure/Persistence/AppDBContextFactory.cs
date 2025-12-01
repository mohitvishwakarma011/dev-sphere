using Microsoft.EntityFrameworkCore.Design;

namespace DS.Infrastructure.Persistence
{
    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString =
                "Data Source=localhost\\SQLEXPRESS;Initial Catalog=devsphere;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

            builder.UseSqlServer(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
