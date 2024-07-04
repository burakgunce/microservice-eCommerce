using ECommerce.Basket.LoginServices;
using ECommerce.Basket.Services;
using ECommerce.Basket.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerce.Basket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub"); // tarayýcý ve vs arasýnda uyusmazlýk oluyo ve sub degerýný yakalayamadýgý ýcýn verýlere erýsýlmýyodu. o hatayý cozen kod

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.Authority = builder.Configuration["IdentityServerUrl"];
                opt.Audience = "ResourceBasket";
                opt.RequireHttpsMetadata = false;
            });

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.Configure<RedisSettings>(builder.Configuration.GetSection("RedisSettings"));
            builder.Services.AddSingleton<RedisService>(sp =>
            {
                var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
                var redis = new RedisService(redisSettings.Host, redisSettings.Port);
                redis.Connect();
                return redis;
            });

            builder.Services.AddControllers(opt =>
            {
                opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy)); //to authorize at project level
            });

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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}