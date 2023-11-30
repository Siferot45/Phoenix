using Phoenix.DAL.Entityes;
using Phoenix.Helpers.Commands;
using Phoenix.Interfaces;
using Phoenix.Services.Interfaces;
using Phoenix.ViewModels.EntityViewModel;
using Phoenix.ViewModels.EntityViewModel.Base;
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

        private readonly IRepository<Massage> _massages;
        private readonly IRepository<Client> _clients;
        private readonly IUserDialog<Client> _userClientDialog;
        private readonly IUserDialog<Massage> _userMassageDialog;

        public MainWindowViewModel(IRepository<Massage> massages, 
                                   IRepository<Client> clients, 
                                   IUserDialog<Client> userClientDialog, 
                                   IUserDialog<Massage> userMassageDialog) 
        {
            _massages = massages;
            _clients = clients;
            _userClientDialog = userClientDialog;
            _userMassageDialog = userMassageDialog;
        }

        #region Команда показа окна массажей

        private ICommand _showMassageViewCommand;

        public ICommand ShowMassageViewCommand => _showMassageViewCommand
            ??= new CommandHelper(OnShowMassageViewCommandExecute, CanShowMassageViewCommandExecute);

        private bool CanShowMassageViewCommandExecute(object obj) => true;

        private void OnShowMassageViewCommandExecute(object obj)
        {
            CurrentModel = new MassageViewModel(_massages, _userMassageDialog);
        }
        #endregion

        #region Команда покказа окна клиентов

        private ICommand _showClientsViewCommand;

        public ICommand ShowClientsViewCommand => _showClientsViewCommand
            ??= new CommandHelper(OnShowClientsViewCommandExecuted, CanShowClientsViewCommandExecute);

        private bool CanShowClientsViewCommandExecute(object obj) => true;

        private void OnShowClientsViewCommandExecuted(object obj)
        {
            CurrentModel = new ClientsViewModel(_clients, _userClientDialog);
        }

        #endregion
    }
}
