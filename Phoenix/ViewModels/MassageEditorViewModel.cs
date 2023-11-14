using Phoenix.DAL.Entityes;
using Phoenix.ViewModels.EntityViewModel.Base;

namespace Phoenix.ViewModels
{
    class MassageEditorViewModel : ViewModelBase
    {
        public int MassageId { get; }
        #region Название массажа
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
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
        public MassageEditorViewModel(Massage massage)
        {
            MassageId = massage.Id;
            Duration = massage?.Duration;
            Description = massage?.Description;
        }
    }
}
