using Phoenix.DAL.Entityes;

namespace Phoenix.Services.Interfaces
{
    /// <summary>
    /// Интерфейс окна добавления и редактирования сущностей
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IUserDialog<in T> where T : class
    {
        bool ConfirmWarning(string warning, string caption);
        bool Edit(T entity);
    }
}
