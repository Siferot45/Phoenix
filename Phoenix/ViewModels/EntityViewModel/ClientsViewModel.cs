using Phoenix.DAL.Entityes;
using Phoenix.Helpers.Commands;
using Phoenix.Interfaces;
using Phoenix.Services.Interfaces;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace Phoenix.ViewModels.EntityViewModel
{
    class ClientsViewModel : ViewModelBase
    {
        private readonly IRepository<Client> _clientsRepository;
        private readonly IUserDialog<Client> _userDialog;

        public ClientsViewModel(IRepository<Client> clientsRepository, IUserDialog<Client> userDialog)
        {
            _clientsRepository = clientsRepository;
            _userDialog = userDialog;
        }

        #region Выбронный клиент 

        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set => Set(ref _selectedClient, value);
        }

        #endregion

        #region Коллекция клиентов

        private ObservableCollection<Client> _clientsCollection;

        public ObservableCollection<Client> ClientsCollection
        {
            get => _clientsCollection;
            set
            {
                if (Set(ref _clientsCollection, value))
                {
                    _clientsViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions = { new SortDescription(nameof(Client.Name), ListSortDirection.Ascending) }
                    };
                    _clientsViewSource.Filter += OnClientsFilter;
                    _clientsViewSource.View.Refresh();

                    OnPropertyChanged(nameof(ClientsViewSource));
                }
            }
        }
        #endregion

        private CollectionViewSource _clientsViewSource;

        public ICollectionView ClientsViewSource => _clientsViewSource?.View;

        #region Фильтр вывода данных

        private string _clientsFilter;
        public string ClientsFilter
        {
            get => _clientsFilter;
            set
            {
                if (Set(ref _clientsFilter, value))
                    _clientsViewSource.View.Refresh();
            }
        }
        private void OnClientsFilter(object sender, FilterEventArgs filterEventArgs)
        {
            if (filterEventArgs.Item is not Client client || string.IsNullOrEmpty(ClientsFilter))
                return;

            if (!client.Name.Contains(ClientsFilter))
                filterEventArgs.Accepted = false;
        }
        #endregion

        #region Команда загрузки даных из репозитория

        private ICommand _loadDataCommand;
        public ICommand LoadDataCommand => _loadDataCommand ??= new CommandHelper(OnLoadDataCommandExecuted, CanLoadDataCommandExecute);

        private bool CanLoadDataCommandExecute(object obj) => true;
        private void OnLoadDataCommandExecuted(object obj)
        {
            ClientsCollection = new ObservableCollection<Client>(_clientsRepository.Items.ToArray());
        }

        #endregion

        #region Команда добавления нового клиента

        private ICommand _addNewClientCommand;
        public ICommand AddNewClientCommand => _addNewClientCommand ??= new CommandHelper(OnAddNewClientCommandExecuted, CanAddNewClientCommandExecute);

        private bool CanAddNewClientCommandExecute(object obj) => true;

        private void OnAddNewClientCommandExecuted(object obj)
        {
            var newClient = new Client();

            if (!_userDialog.ShowEditWindow(newClient, ClientsCollection))
                return;

            _clientsCollection.Add(_clientsRepository.Add(newClient));
        }

        #endregion

        #region Команда удаления клиента

        private ICommand _deleteClientCommand;
        public ICommand DeleteClientCommand => _deleteClientCommand ??= new CommandHelperT<Client>(OnDeleteClientCommandExecuted, CanDeleteClientCommandExecute);

        private bool CanDeleteClientCommandExecute(Client c) => c != null || SelectedClient != null;

        private void OnDeleteClientCommandExecuted(Client c)
        {
            var clientToDelete = c ?? SelectedClient;

            if (!_userDialog.ConfirmWarning($"Вы хотите удалить {clientToDelete.Name} {clientToDelete.Patronymic}?", "Удаление клиента"))
                return;

            _clientsRepository.Delete(clientToDelete.Id);

            _clientsCollection.Remove(clientToDelete);

            if (ReferenceEquals(SelectedClient, clientToDelete))
                SelectedClient = null;
        }
        #endregion

        #region Команда редактирования клиента

        private ICommand _editClientCommand;
        public ICommand EditClientCommand => _editClientCommand ??= new CommandHelperT<Client>(OnEditClientCommandExecuted, CanEditClientCommandExecute);

        private bool CanEditClientCommandExecute(Client c) => c != null || SelectedClient != null;

        private void OnEditClientCommandExecuted(Client c)
        {
            var newClient = SelectedClient;

            if (!_userDialog.ShowEditWindow(newClient, ClientsCollection))
                return;

            var oldClient = _clientsCollection.FirstOrDefault(c => c.Id == newClient.Id);

            _clientsCollection.Remove(oldClient);
            _clientsCollection.Add(newClient);
            _clientsRepository.Update(newClient);
            SelectedClient = newClient;
        }

        #endregion
    }
}
