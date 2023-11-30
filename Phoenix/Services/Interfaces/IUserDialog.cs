using System.Collections.ObjectModel;

namespace Phoenix.Services.Interfaces
{
    /// <summary>
    /// Интерфейс окна добавления и редактирования сущностей
    /// </summary>
    /// <typeparam name="T">classEntity</typeparam>
    internal interface IUserDialog<T> where T : class
    {
        /// <summary>
        /// Окно предупреждения выбора да/нет
        /// </summary>
        /// <param name="warning"></param>
        /// <param name="caption"></param>
        /// <returns></returns>
        bool ConfirmWarning(string warning, string caption);
        /// <summary>
        /// Обращение к окну добавления и редактирования 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool ShowEditWindow(T entity, ObservableCollection<T> entityCollection);

    }
}
