using Phoenix.DAL.Entityes;
using Phoenix.ViewModels.EntityViewModel.Base;

namespace Phoenix.ViewModels
{
    internal class ClientEditorViewModel : ViewModelBase
    {
        public int ClientId { get; }

        #region Имя клиента

        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        #endregion

        public ClientEditorViewModel(Client client)
        {
            ClientId = client.Id;
            Name = client.Name;
        }
    }
}
