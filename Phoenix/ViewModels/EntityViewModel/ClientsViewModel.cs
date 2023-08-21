
using Phoenix.DAL.Entityes;
using Phoenix.Interfaces;
using Phoenix.ViewModels.EntityViewModel.Base;

namespace Phoenix.ViewModels.EntityViewModel
{
     class ClientsViewModel : ViewModelBase
    {
        private readonly IRepository<Client> _clientsRepository;

        public ClientsViewModel(IRepository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }
    }
}
