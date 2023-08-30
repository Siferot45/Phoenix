using Microsoft.Extensions.DependencyInjection;
using Phoenix.DAL.Entityes;
using Phoenix.Services.Interfaces;

namespace Phoenix.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IUserDialog<Client>, ClientDialogServise>()
            ;
    }
}
