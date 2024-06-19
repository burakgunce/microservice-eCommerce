using Ecommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Ecommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Ecommerce.Order.Application.Interfaces;
using Ecommerce.Order.Application.Services;
using ECommerce.Order.Persistence.Context;
using ECommerce.Order.Persistence.Repositories;


namespace ECommerce.Order.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddDbContext<OrderContext>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
            builder.Services.AddApplicationService(builder.Configuration);

            builder.Services.AddScoped<GetAddressQueryHandler>();
            builder.Services.AddScoped<GetAddressByIdQueryHandler>();
            builder.Services.AddScoped<CreateAddressCommandHandler>();
            builder.Services.AddScoped<UpdateAddressCommandHandler>();
            builder.Services.AddScoped<RemoveAddressCommandHandler>();

            builder.Services.AddScoped<GetOrderDetailQueryHandler>();
            builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
            builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
            builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
            builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();

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