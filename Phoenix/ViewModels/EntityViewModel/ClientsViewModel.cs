using Phoenix.DAL.Entityes;
using Phoenix.Helpers.Commands;
using Phoenix.Interfaces;
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

        public ClientsViewModel(IRepository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
        private ObservableCollection<Client> _clientsCollection;

        public ObservableCollection<Client> ClientsCollection
        {
            get => _clientsCollection;
            set 
            {
                if(Set(ref _clientsCollection, value))
                {
                    _clientsViewSource = new CollectionViewSource
                    {
                        Source = value,
                        SortDescriptions = {new SortDescription(nameof(Client.Name), ListSortDirection.Ascending)}
                    };
                    _clientsViewSource.Filter += OnClintsFilter;
                    _clientsViewSource.View.Refresh();

                    OnPropertyChanged(nameof(ClientsViewSource));
                }
            } 
        }
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
        private void OnClintsFilter(object sender, FilterEventArgs filterEventArgs)
        {
            if (!(filterEventArgs.Item is Client client) || string.IsNullOrEmpty(ClientsFilter))
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
    }
}
