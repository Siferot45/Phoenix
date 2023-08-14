using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.DAL.Context;
using System;

namespace Phoenix.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddDbContext<PhoenixDB>(opt =>
            {
                var type = configuration["Type"];

                switch (type)
                {
                    case "postgres":
                        opt.UseNpgsql(configuration.GetConnectionString(type));
                        opt.UseSnakeCaseNamingConvention();
                        break;

                    case null:
                        throw new InvalidOperationException("Неизвестный тип БД");

                    default:
                        throw new InvalidOperationException($"Подключение {type} не поддерживаеся");
                }
            })
            .AddTransient<DbInitializer>()
            ;
    }
}
