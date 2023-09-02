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

        #region Фамилия клиента 

        private string _surname;
        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }
        #endregion

        #region Отчество клиента 

        private string _patronymic;
        public string Patronymic
        {
            get => _patronymic;
            set => Set(ref _patronymic, value);
        }
        #endregion
        
        #region Телифон клиента 

        private long? _phone;
        public long? Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }
        #endregion

        public ClientEditorViewModel(Client client)
        {
            ClientId = client.Id;
            Name = client.Name;
            Surname = client.Surname;
            Patronymic = client.Patronymic;
            Phone = client.Phone;
        }
    }
}
