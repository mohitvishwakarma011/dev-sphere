using DS.Api.Middlewares;
using DS.Api.Validators.User;

namespace DS.Api
{
    public static class Extensions
    {
        public static void LoadAppSetting(this IConfiguration configuration)
        {
            //AppSettings.Database.Server = Environment.GetEnvironmentVariable();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }

        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
        }

        public static void ConfigureMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandling>();
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserModel>, UserUpsertValidator>();
        }
    }
}
