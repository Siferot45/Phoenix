using Phoenix.DAL.Entityes;
using Phoenix.Services.Interfaces;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Phoenix.ViewModels
{
    class MassageEditorViewModel : ViewModelBase
    {
        private readonly IUserDialog<Category> _userCategoryDialog;
        public int MassageId { get; }

        #region Колеция массажей

        private ObservableCollection<Massage> _massageCollection;
        public ObservableCollection<Massage> MassageCollection 
        {
            get => _massageCollection;
            set => Set(ref _massageCollection, value);
        }
        #endregion

        #region Название массажа
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        #endregion
        public List<Category> categoryCollection { get; set; }
        #region Категория массажа
        private string? _category;
        public string? Category
        {
            get => _category;
            set => Set(ref _category, value);
        }
        #endregion

        #region Продолжительность массажа

        private int? _duration;
        public int? Duration
        {
            get => _duration;
            set => _duration = value;
        }
        #endregion

        #region Описание массажа

        private string? _description;
        public string? Description
        {
            get => _description; 
            set => Set(ref _description, value);
        }
        
        #endregion

        /// <summary>
        /// Конструктор с отображением ранние веденой информации о массаже
        /// </summary>
        public MassageEditorViewModel(Massage massage, ObservableCollection<Massage> massageCollection)
        { 
            _massageCollection = massageCollection;
            categoryCollection = GetCategoryCollection(_massageCollection);
            MassageId = massage.Id;
            Name = massage.Name;
            Category = massage?.Category?.Name;
            Duration = massage?.Duration;
            Description = massage?.Description;
        }

        #region Фильтр массажей
        /// <summary>
        /// Забирает из коллекции массажей категории
        /// </summary>
        /// <param name="massageCollection">ObservableCollection<Massage></param>
        /// <returns>List<Category></returns>
        public List<Category> GetCategoryCollection(ObservableCollection<Massage> massageCollection)
        {
            categoryCollection = massageCollection.Select(e => e.Category).ToList();
            return categoryCollection;
        }
        #endregion
    }
}
