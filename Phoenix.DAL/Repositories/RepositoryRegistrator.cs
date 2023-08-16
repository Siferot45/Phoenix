using Microsoft.Extensions.DependencyInjection;
using Phoenix.DAL.Entityes;
using Phoenix.Interfaces;

namespace Phoenix.DAL.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoryInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Massage>, MassageRepository>()
            .AddTransient<IRepository<Category>, DbRepository<Category>>()
            .AddTransient<IRepository<Master>, DbRepository<Master>>()
            .AddTransient<IRepository<Client>, DbRepository<Client>>()
            .AddTransient<IRepository<Visit>, VisitsRepository>()
            ;
    }
}
