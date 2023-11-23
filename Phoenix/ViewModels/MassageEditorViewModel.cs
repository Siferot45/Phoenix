using Phoenix.DAL.Entityes;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Phoenix.ViewModels
{
    class MassageEditorViewModel : ViewModelBase
    {
        public List<string> CategoryName { get; set; }
        public int MassageId { get; }
        #region Название массажа
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        #endregion

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
            set => Set(ref _duration, value);
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
        /// <param name="massage"></param>
        public MassageEditorViewModel(Massage massage, List<string> categoryName)
        {
            CategoryName = categoryName;
            MassageId = massage.Id;
            Name = massage.Name;
            Category = massage?.Category?.Name;
            Duration = massage?.Duration;
            Description = massage?.Description;
        }
        public MassageEditorViewModel(Massage massage)
        {

            MassageId = massage.Id;
            Name = massage.Name;
            Category = massage?.Category?.Name;
            Duration = massage?.Duration;
            Description = massage?.Description;
        }

    }
}
