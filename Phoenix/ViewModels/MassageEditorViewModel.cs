using Phoenix.DAL.Entityes;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Phoenix.ViewModels
{
    class MassageEditorViewModel : ViewModelBase
    {
        public int MassageId { get; }

        #region Название массажа
        /// <summary>
        /// Название массажа
        /// </summary>
        private string _name ;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        #endregion

        #region Лист категорий
        private List<Category> _categoryCollection;
        public List<Category> CategoryCollection 
        {
            get => _categoryCollection;
            set => Set(ref _categoryCollection, value);
        }
        #endregion

        #region Категория массажа строковая
        /// <summary>
        /// string CategoryName
        /// </summary>
        private string? _categoryName;
        public string? CategoryName
        {
            get => _categoryName;
            set => Set(ref _categoryName, value);
        }
        #endregion

        #region Категория массажа сущность
        /// <summary>
        /// Категория массажа Entity
        /// </summary>
        private Category? _newCategory;
        public Category? NewCategory
        {
            get => _newCategory;
            set => Set(ref _newCategory, value);
        }

        #endregion
        
        public int? Duration { get; set; }

        #region Описание массажа

        private string? _description;
        public string? Description
        {
            get => _description; 
            set => Set(ref _description, value);
        }

        #endregion

        /// <summary>
        /// Конструктор с отображением ранние веденой информации о массаже и фильтром массажей
        /// </summary>
        public MassageEditorViewModel(Massage massage, ObservableCollection<Massage> massageCollection)
        {
            CategoryCollection = GetCategoryCollection(massageCollection);
            MassageId = massage.Id;
            Name = massage.Name;
            CategoryName = massage?.Category?.Name;
            Duration = massage?.Duration;
            Description = massage?.Description;
        }

        #region Фильтр массажей избавление от дублей
        /// <summary>
        /// Забирает из коллекции массажей категории
        /// </summary>
        /// <param name="massageCollection">ObservableCollection<Massage></param>
        /// <returns>List<Category></returns>
        public static List<Category> GetCategoryCollection(ObservableCollection<Massage> massageCollection)
        {
            List<Category> categories = massageCollection.Select(e => e.Category).ToList();

            return categories.DistinctBy(i => i?.Name).ToList();
        }
        #endregion

        #region Получить категорию установленную в диалоге
        /// <summary>
        /// Получить категорию установленную в диалоге
        /// </summary>
        /// <param name="nameCategory">Значение из Combo box</param>
        public Category GetCategory(string nameCategory)
        {
            if(nameCategory == null)
                nameCategory = "Без категории";

            NewCategory = new Category();

            NewCategory = CategoryCollection.FirstOrDefault(c => c?.Name == nameCategory) ?? new Category { Name = nameCategory };

            return NewCategory;
        
        #endregion
        }
    }
}
