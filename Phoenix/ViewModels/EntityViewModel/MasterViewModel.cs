using Phoenix.DAL.Entityes;
using Phoenix.Helpers.Commands;
using Phoenix.Interfaces;
using Phoenix.Services.Interfaces;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Phoenix.ViewModels.EntityViewModel
{
    internal class MasterViewModel : ViewModelBase
    {
        private readonly IRepository<Master> _masterRepository;
        private readonly IUserDialog<Master> _masterDialog;

        public MasterViewModel(IRepository<Master> masterRepository, IUserDialog<Master> masterDialog)
        {
            _masterRepository = masterRepository;
            _masterDialog = masterDialog;
        }
        #region Master collection

        private ObservableCollection<Master> _mastersCollection;  
        public ObservableCollection<Master> MastersCollection
        {
            get => _mastersCollection;
            set => Set(ref _mastersCollection, value);
        }
        #endregion

        #region Selected master
        private Master? _selectedMaster;
        public Master? SelectedMaster
        {
            get => _selectedMaster;
            set => Set(ref _selectedMaster, value);
        }
        #endregion

        #region The command to load download data from the repository

        private ICommand _loadCommand;
        public ICommand LoadCommand => _loadCommand ??= new CommandHelper(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute(object obj) => true;
        private void OnLoadDataCommandExecuted(object obj) => MastersCollection = new ObservableCollection<Master>(_masterRepository.Items.ToArray());

        #endregion

        #region The download command for addind the master

        private ICommand _addNewMasterCommand;
        public ICommand AddNewMasterCommand => _addNewMasterCommand ??= new CommandHelper(OnAddNewMasterCommandExecuted, CanAddNewMasterCommandExecute);

        private bool CanAddNewMasterCommandExecute(object obj) => true;

        private void OnAddNewMasterCommandExecuted(object obj)
        {
            var newMaster = new Master();

            if (!_masterDialog.ShowEditWindow(newMaster, MastersCollection))
                return;

            _mastersCollection.Add(_masterRepository.Add(newMaster));
        }
        #endregion

        #region The master removal command

        private ICommand _deleteMasterCommand;
        public ICommand DeleteMasterCommand => _deleteMasterCommand ??= new CommandHelperT<Master>(OnDeleteMasterCommandExecuted, CanDeleteMasterCommandExecute);

        private bool CanDeleteMasterCommandExecute(Master m) => m != null || SelectedMaster != null;
        private void OnDeleteMasterCommandExecuted(Master m)
        {
            var masterToDeleted = m ?? SelectedMaster;

            if (!_masterDialog.ConfirmWarning($"Вы хотите удалить {masterToDeleted.Name} {masterToDeleted.Patronymic}?", "Удаление мастера"))
                return;

            _masterRepository.Delete(masterToDeleted.Id);
            _mastersCollection.Remove(masterToDeleted);

            if (ReferenceEquals(SelectedMaster, masterToDeleted))
                SelectedMaster = null;
        }
        #endregion
    }
}
