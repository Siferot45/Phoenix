using Phoenix.DAL.Entityes;
using Phoenix.DAL.Entityes.Base;
using Phoenix.Interfaces;
using Phoenix.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace Phoenix.Services
{
    internal class UserDialog<T> : IUserDialog<T> where T : EntityBase
    {
        public virtual bool ShowEditWindow(T entity, ObservableCollection<T> entityCollection) => true;
        public bool ConfirmWarning(string warning, string caption) => MessageBox.Show(
            warning, caption, MessageBoxButton.YesNo, MessageBoxImage.Warning ) == MessageBoxResult.Yes;

        public virtual bool ShowCategoryWindow(List<T> categoryList) => true;
    }
}
