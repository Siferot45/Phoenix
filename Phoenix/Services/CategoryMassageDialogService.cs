using Phoenix.DAL.Entityes;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;
using System.Collections.Generic;

namespace Phoenix.Services
{
    internal class CategoryMassageDialogService : UserDialog<Category>
    {
        public override bool ShowCategoryWindow(List<Category> categoryList)
        {
            var categoryEditorModel = new CategoryEditorViewModel(categoryList);

            var categoryEditorWindow = new CategoryMassageWindow()
            {
                DataContext = categoryEditorModel
            };

            if(categoryEditorWindow.ShowDialog() != true)
                return false;

            return true;
        }
    }
}
