using DS.Api.Middlewares;
using DS.Api.Validators.Post;
using DS.Api.Validators.User;
using Microsoft.EntityFrameworkCore;

namespace DS.Api
{
    public static class Extensions
    {
        public static void LoadAppSetting(this IConfiguration configuration)
        {
            //AppSettings.Database.Server = Environment.GetEnvironmentVariable();
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=devsphere;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");
            });
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<ISeedRepository,SeedRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

        }

        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ISeedManager, SeedManager>();
            services.AddScoped<IPostManager, PostManager>();
        }

        public static void ConfigureMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandling>();
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserModel>, UserUpsertValidator>();
            services.AddScoped<IValidator<PostModel>, PostValidator>();

        }
    }
}
