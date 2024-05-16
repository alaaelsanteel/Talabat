using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Talabat.APIs.Errors;
using Talabat.APIs.Extensions;
using Talabat.APIs.Helper;
using Talabat.APIs.Middlewares;
using Talabat.Core.Data;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the DI container.

            #region Configure Services
            //register required web APIs Services to DI
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerServices();

            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAplicationServices();

            #endregion

            var app = builder.Build();
            
             using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;//to get obj of scoped services
            var _dbContext = services.GetRequiredService<StoreContext>();
            // ask CLR for creating obj from dbContext Explicitly
            
            //used to make the formate exception make it readable 
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await _dbContext.Database.MigrateAsync(); //if there's smt wrong with migration run the app normal
                await StoreContextSeed.SeedAsync(_dbContext); //Data seeding
            }
            catch (Exception ex) 
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has been occured during applying migrations");
                
            }


            // Configure the HTTP request pipeline.

            app.UseMiddleware<ExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); //do the routing for t he endpoints 

            app.Run();
        }
    }
}