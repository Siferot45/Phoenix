using Phoenix.DAL.Entityes;
using Phoenix.DAL.Entityes.Base;
using Phoenix.Services.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace Phoenix.Services
{
    internal class UserDialog<T> : IUserDialog<T> where T : EntityBase
    {
        public virtual bool Edit(T entity) => true;
        public bool ConfirmWarning(string warning, string caption) => MessageBox.Show(
            warning, caption, MessageBoxButton.YesNo, MessageBoxImage.Warning ) == MessageBoxResult.Yes;

        public virtual bool Add(T entity, List<string> categoriesName)
        {
            throw new System.NotImplementedException();
        }
    }
}
