using Phoenix.DAL.Entityes;

namespace Phoenix.Services.Interfaces
{
    internal interface IUserDialog<in T> where T : class
    {
        bool Edit(T entity);
    }
}
