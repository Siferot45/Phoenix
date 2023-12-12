using Phoenix.DAL.Entityes;
using Phoenix.ViewModels.EntityViewModel.Base;

namespace Phoenix.ViewModels
{
    internal class MasterEditorViewModel
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public MasterEditorViewModel(Master master)
        {
            Name = master.Name;
            Surname = master.Surname;
            Patronymic = master.Patronymic;
        }
    }
}
