using Microsoft.EntityFrameworkCore;
using SqlDataAccess.Context;

namespace ThermalCalculations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddControllers();

            builder.Services.AddDbContextFactory<DatabaseContext>(options => options.UseSqlServer("server=DESKTOP-9FN9TUU\\SQLEXPRESS; database=ThermalCalculations; Trusted_Connection=True; TrustServerCertificate=True; Connection Timeout=30"));



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}