using Phoenix.DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Phoenix.Services.Interfaces
{
    /// <summary>
    /// Интерфейс окна добавления и редактирования сущностей
    /// </summary>
    /// <typeparam name="T">classEntity</typeparam>
    internal interface IUserDialog<T> where T : class
    {
        bool ConfirmWarning(string warning, string caption);
        /// <summary>
        /// Обращение к окну редактирования 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Edit(T entity);
        bool Add(T entity, List<string> categoriesName);
    }
}
