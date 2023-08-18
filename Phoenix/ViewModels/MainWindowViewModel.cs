using Phoenix.DAL.Entityes;
using Phoenix.Helpers.Commands;
using Phoenix.Interfaces;
using Phoenix.ViewModels.EntityViewModel.Base;
using System;
using System.Windows.Input;

namespace Phoenix.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Заголовок
        private string _title = "Главная страница";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Текущая модель предстовления
        private ViewModelBase _currentModel;
        public ViewModelBase CurrentModel
        {
            get => _currentModel;
            set => Set(ref _currentModel, value);
        }
        #endregion

        private readonly IRepository<Massage> _massage;

        public MainWindowViewModel(IRepository<Massage> massage)
        {
            _massage = massage;
        }

        private ICommand _showMassageViewCommand;

        public ICommand ShowMassageViewCommand => _showMassageViewCommand
            ??= new CommandHelper(OnShowMassageViewCommandExecute, CanShowMassageViewCommandExecute);

        private bool CanShowMassageViewCommandExecute() => true;

        private void OnShowMassageViewCommandExecute(object obj)
        {
            CurrentModel = new MassageViewModel(_massage);
        }
    }
}
