using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DS.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.LoadAppSetting();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer(); 
            builder.Services.AddSwaggerGen();

            //Add DbContext
            builder.Services.ConfigureDatabase();
            builder.Services.ConfigureDefaults();
            builder.Services.ConfigureIdentity();

            builder.Services.ConfigureRepositories();
            builder.Services.ConfigureManagers();
            builder.Services.ConfigureValidators();
            
            var app = builder.Build();
            //app.ConfigureMiddlewares(); //Configure Middlewares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
