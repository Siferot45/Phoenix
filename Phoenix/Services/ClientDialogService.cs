using Phoenix.DAL.Entityes;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;


namespace Phoenix.Services
{
    internal class ClientDialogService : UserDialog<Client>
    {
        /// <summary>
        /// Вызов окна добавления и редактирования, установка в веденых значений
        /// </summary>
        /// <param name="client"></param>
        /// <returns>bool</returns>
        public override bool Edit(Client client)
        {
            var clientEditorModel = new ClientEditorViewModel(client);

            var clientEditorWindow = new ClientEditorWindow
            {
                DataContext = clientEditorModel
            };

            if (clientEditorWindow.ShowDialog() != true)
                return false;

            client.Name = clientEditorModel.Name;
            client.Surname = clientEditorModel.Surname;
            client.Patronymic = clientEditorModel.Patronymic;
            client.Phone = clientEditorModel.Phone;
            client.Description = clientEditorModel.Description;

            return true;
        }
    }
}
