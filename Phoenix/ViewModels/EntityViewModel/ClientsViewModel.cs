using Microsoft.EntityFrameworkCore;
using Phoenix.DAL.Entityes;
using Phoenix.Helpers.Commands;
using Phoenix.Interfaces;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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
                        Source = value
                    };
                    OnPropertyChanged(nameof(ClientsViewSource));
                }
            } 
        }
        private CollectionViewSource _clientsViewSource;
        public ICollectionView ClientsViewSource => _clientsViewSource?.View;

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
