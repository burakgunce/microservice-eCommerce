using ECommerce.Cargo.Business.Abstract;
using ECommerce.Cargo.Business.Concrete;
using ECommerce.Cargo.DataAccess.Abstract;
using ECommerce.Cargo.DataAccess.Context;
using ECommerce.Cargo.DataAccess.EntityFramework;

namespace ECommerce.Cargo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CargoContext>();

            builder.Services.AddScoped<ICargoCompanyDal, EfCargoCompanyDal>();
            builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            builder.Services.AddScoped<ICargoCustomerDal, EfCargoCustomerDal>();
            builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            builder.Services.AddScoped<ICargoDetailDal, EfCargoDetailDal>();
            builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
            builder.Services.AddScoped<ICargoOperationDal, EfCargoOperationDal>();
            builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();

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