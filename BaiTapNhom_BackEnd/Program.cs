using BaiTapNhom_BackEnd.Data;
using BaiTapNhom_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiTapNhom_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BaiTapNhomBackEndDBConText>(option => option.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            builder.Services.AddDbContext<TodoContext>(option => option.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            // Add services to the container.

            builder.Services.AddControllers();
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