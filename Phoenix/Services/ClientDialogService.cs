using Phoenix.DAL.Entityes;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;
using System.Collections.ObjectModel;

namespace Phoenix.Services
{
    /// <summary>
    /// Переопределение окна диалога для массажа
    /// </summary>
    internal class ClientDialogService : UserDialog<Client>
    {
        /// <summary>
        /// Вызов окна добавления и редактирования, установка в веденых значений для клиента
        /// </summary>
        /// <param name="client"></param>
        /// <returns>bool</returns>
        public override bool ShowEditWindow(Client client, ObservableCollection<Client> entityCollection)
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
