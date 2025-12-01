using DS.Api.Middlewares;
using DS.Api.Validators.Category;
using DS.Api.Validators.Comment;
using DS.Api.Validators.Post;
using DS.Api.Validators.User;
using DS.Core;
using DS.Core.Dto.Category;
using DS.Core.Dto.Comment;
using DS.Core.Entities;
using DS.Core.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DS.Api
{
    public static class Extensions
    {
        public static void LoadAppSetting(this IConfiguration configuration)
        {
            AppSetting.ValidOrigins = Environment.GetEnvironmentVariable("APP_VALID_ORIGINS").Split(',', StringSplitOptions.RemoveEmptyEntries) ?? throw new KeyNotFoundException();


            AppSetting.Database.DataSource = Environment.GetEnvironmentVariable("MSSQL_DATA_SOURCE") ?? throw new KeyNotFoundException();
            AppSetting.Database.Catalog = Environment.GetEnvironmentVariable("MSSQL_INITIAL_CATALOG") ?? throw new KeyNotFoundException();
            AppSetting.Database.TrustedConnection = Environment.GetEnvironmentVariable("MSSQL_TRUSTED_CONNECTION") ?? throw new KeyNotFoundException();
            AppSetting.Database.MultipleActiveResultSets = Environment.GetEnvironmentVariable("MSSQL_MULTIPLE_ACTIVE_RESULT_SETS") ?? throw new KeyNotFoundException();
            AppSetting.Database.TrustServerCertificate = Environment.GetEnvironmentVariable("MSSQL_TRUST_SERVER_CERTIFICATE") ?? throw new KeyNotFoundException();
            AppSetting.Database.IntegratedSecurity = Environment.GetEnvironmentVariable("MSSQL_INTEGRATED_SECURITY") ?? throw new KeyNotFoundException();
            //AppSetting.Database.UserName = Environment.GetEnvironmentVariable("MSSQL_USER") ?? throw new KeyNotFoundException();
            //AppSetting.Database.Password = Environment.GetEnvironmentVariable("MSSQL_PASSWORD") ?? throw new KeyNotFoundException();
            AppSetting.Jwt.Issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? string.Empty;
            AppSetting.Jwt.Audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? string.Empty;
            AppSetting.Jwt.Secret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? string.Empty;
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(AppSetting.GetConnectionString());
            });
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISeedRepository, SeedRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

        }

        public static void ConfigureManagers(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ISeedManager, SeedManager>();
            services.AddScoped<IPostManager, PostManager>();
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICommentManager, CommentManager>();

        }

        public static void ConfigureMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionHandling>();
        }

        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<UserModel>, UserUpsertValidator>();
            services.AddScoped<IValidator<PostModel>, PostValidator>();
            services.AddScoped<IValidator<UpdateCategoryDto>, UpdateCategoryValidator>();
            services.AddScoped<IValidator<CategoryDto>, CategoryValidator>();
            services.AddScoped<IValidator<UpsertCommentDto>, UpsertCommentValidator>();

        }

        public static void ConfigureDefaults(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Constants.DefaultCorsPolicy,
                builder => builder.WithOrigins(AppSetting.ValidOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidIssuer = AppSetting.Jwt.Issuer,
                     ValidAudience = AppSetting.Jwt.Audience,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSetting.Jwt.Secret)),
                     ValidateIssuer = true,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ClockSkew = TimeSpan.Zero
                 };
             });
        }
    }
}
