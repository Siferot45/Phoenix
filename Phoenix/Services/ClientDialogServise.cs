using Phoenix.DAL.Entityes;
using Phoenix.Services.Interfaces;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;


namespace Phoenix.Services
{
    internal class ClientDialogServise : UserDialog<Client>
    {
        public override bool Edit(Client client)
        {
            var clientEditorModel = new ClientEditorViewModel(client);

            var clientEditorWindow = new ClientEditorWindow
            {
                DataContext = clientEditorModel
            };

            if(clientEditorWindow.ShowDialog() != true)
                return false;

            client.Name = clientEditorModel.Name;
            client.Surname = clientEditorModel.Surname;
            client.Patronymic = clientEditorModel.Patronymic;
            client.Phone = clientEditorModel.Phone;

            return true;
        }
    }
}
