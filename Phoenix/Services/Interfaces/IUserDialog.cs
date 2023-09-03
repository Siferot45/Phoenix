using Phoenix.DAL.Entityes;

namespace Phoenix.Services.Interfaces
{
    internal interface IUserDialog<in T> where T : class
    {
        bool ConfirmWarning(string warning, string caption);
        bool Edit(T entity);
    }
}
