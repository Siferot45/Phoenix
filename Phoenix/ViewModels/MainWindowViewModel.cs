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

        private readonly IRepository<Massage> _massagesRepository;
        private readonly IRepository<Client> _clientsRepository;
        private readonly IRepository<Master> _masterRepository;
        private readonly IUserDialog<Client> _userClientDialog;
        private readonly IUserDialog<Massage> _userMassageDialog;
        private readonly IUserDialog<Master> _userMasterDialog;

        public MainWindowViewModel(IRepository<Massage> massagesRepository, 
                                   IRepository<Client> clientsRepository,
                                   IRepository<Master> masterRepository,
                                   IUserDialog<Client> userClientDialog, 
                                   IUserDialog<Massage> userMassageDialog,
                                   IUserDialog<Master> userMasterDialog) 
        {
            _massagesRepository = massagesRepository;
            _clientsRepository = clientsRepository;
            _masterRepository = masterRepository;
            _userClientDialog = userClientDialog;
            _userMassageDialog = userMassageDialog;
            _userMasterDialog = userMasterDialog;
        }

        #region Команда показа окна массажей

        private ICommand _showMassageViewCommand;

        public ICommand ShowMassageViewCommand => _showMassageViewCommand
            ??= new CommandHelper(OnShowMassageViewCommandExecute, CanShowMassageViewCommandExecute);

        private bool CanShowMassageViewCommandExecute(object obj) => true;

        private void OnShowMassageViewCommandExecute(object obj)
        {
            CurrentModel = new MassageViewModel(_massagesRepository, _userMassageDialog);
        }
        #endregion

        #region Команда показа окна клиентов

        private ICommand _showClientsViewCommand;

        public ICommand ShowClientsViewCommand => _showClientsViewCommand
            ??= new CommandHelper(OnShowClientsViewCommandExecuted, CanShowClientsViewCommandExecute);

        private bool CanShowClientsViewCommandExecute(object obj) => true;

        private void OnShowClientsViewCommandExecuted(object obj)
        {
            CurrentModel = new ClientsViewModel(_clientsRepository, _userClientDialog);
        }

        #endregion

        #region Master windows display command

        private ICommand _showMastersViewCommand;

        public ICommand ShowMasterViewCommand => _showMastersViewCommand
            ??= new CommandHelper(OnShowMasterViewCommandExecuted, CanShowMasterViewCommandExecute);

        private bool CanShowMasterViewCommandExecute(object obj) => true;

        private void OnShowMasterViewCommandExecuted(object obj)
        {
            CurrentModel = new MasterViewModel(_masterRepository, _userMasterDialog);
        }
        #endregion
    }
}
