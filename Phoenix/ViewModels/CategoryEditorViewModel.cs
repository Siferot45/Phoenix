using Phoenix.DAL.Entityes;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.Generic;

namespace Phoenix.ViewModels
{
    class CategoryEditorViewModel : ViewModelBase 
    {
        #region Колекция категорий

        private List<Category> _categoriesList;
        public List<Category> CategoriesList
        {
            get => _categoriesList;
            set => Set(ref _categoriesList, value);
        }
        #endregion

        public CategoryEditorViewModel(List<Category> categoryList)
        {
            CategoriesList = categoryList;
        }

        //#region Команда загрузки категорий

        //private ICommand _loadCategoryCommand;

        //public ICommand LoadCategoryCommand => _loadCategoryCommand ??= new CommandHelper(OnLoadCategoryCommandExecuted, CanLoadCategoryCommandExecute);
        //private bool CanLoadCategoryCommandExecute(object obj) => true;
        //private void OnLoadCategoryCommandExecuted(object obj)
        //{
            
        //}
        //#endregion

    }
}
