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
    class MassageViewModel : ViewModelBase
    {
        private readonly IRepository<Massage> _massageRepository;
        private readonly IUserDialog<Massage> _userDialog;

        public MassageViewModel(IRepository<Massage> massageRepository, IUserDialog<Massage> userDialog)
        {
            _massageRepository = massageRepository;
            _userDialog = userDialog;
        }

        #region Колекция массажистов

        private ObservableCollection<Massage> _massagesCollection;
        public ObservableCollection<Massage> MassagesCollection
        {
            get => _massagesCollection;
            set => Set(ref _massagesCollection, value);
        }
        #endregion

        #region Выбронный клиент

        private Massage _selectedMassage;
        public Massage SelectedMassage 
        {
            get => _selectedMassage;
            set => Set(ref _selectedMassage, value);
        }
        #endregion

        #region Команда загрузки даных из репозитория

        private ICommand _loadDataCommand;
        public ICommand LoadDataCommand => _loadDataCommand ??= new CommandHelper(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute(object odj) => true;

        private void OnLoadDataCommandExecuted(object odj)
        {
            MassagesCollection = new ObservableCollection<Massage>(_massageRepository.Items.ToArray());
        }
        #endregion

        #region Добавить новый массаж

        private ICommand _addNewMassageCommand;
        public ICommand AddNewMassageCommand => _addNewMassageCommand ??= new CommandHelper(OnAddNewMassageCommandExecuted, CanAddNewMassageCommandExecute);

        private bool CanAddNewMassageCommandExecute(object odj) => true;

        private void OnAddNewMassageCommandExecuted(object odj)
        {
            var newMassage = new Massage();

            if (!_userDialog.Edit(newMassage))
                return;

            _massagesCollection.Add(_massageRepository.Add(newMassage));
        }
        #endregion

        #region Удалить массаж

        private ICommand _deleteMassageCommand;
        public ICommand DeleteMassageCommand => _deleteMassageCommand ??= new CommandHelperT<Massage>(OnDeleteMassageCommandExecuted, CanDeleteMassageCommandExecute);

        private bool CanDeleteMassageCommandExecute(Massage m) => m != null || SelectedMassage != null;

        private void OnDeleteMassageCommandExecuted(Massage m)
        {
            var massageToDelete = m ?? SelectedMassage;

            if (!_userDialog.ConfirmWarning($"Вы хотите удалить {massageToDelete.Name} категории {massageToDelete.Category}?", "Удаление массажа")) 
                return;

            _massageRepository.Delete(massageToDelete.Id);
            _massagesCollection.Remove(massageToDelete);
        }
        #endregion

        #region Команда редактирования клиента

        private ICommand _editMassageCommand;
        public ICommand EditMassageCommand => _editMassageCommand ??= new CommandHelperT<Massage>(OnEditMassageCommandExecuted, CanEditMassageCommandExecute);

        private bool CanEditMassageCommandExecute(Massage m) => m != null || SelectedMassage != null;

        private void OnEditMassageCommandExecuted(Massage m)
        {
            var newMassage = SelectedMassage;

            if (!_userDialog.Edit(newMassage))
                return;

            var oldMassage = _massagesCollection.FirstOrDefault(m => m.Id == newMassage.Id);

            _massagesCollection.Remove(oldMassage);
            _massagesCollection.Add(newMassage);

            _massageRepository.Update(newMassage);

            SelectedMassage = newMassage;
        }
        #endregion
    }
    }
