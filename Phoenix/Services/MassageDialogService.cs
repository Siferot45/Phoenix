using Phoenix.DAL.Entityes;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;

namespace Phoenix.Services
{
    /// <summary>
    /// Переопределение окна диалога для массажа
    /// </summary>
    internal class MassageDialogService : UserDialog<Massage>
    {
        /// <summary>
        /// Вызов окна добавления и редактирования, установка в веденых значений для массажа
        /// </summary>
        /// <param name="massage"></param>
        /// <returns>bool</returns>
        public override bool Edit(Massage massage)
        {
            var massageEditorModel = new MassageEditorViewModel(massage);

            var massageEditorWindow = new MassageEditorWindow
            {
                DataContext = massageEditorModel
            };

            if (massageEditorWindow.ShowDialog() != true)
                return false;

            massage.Name = massageEditorModel.Name;
            massage.Duration = massageEditorModel.Duration;
            massage.Description = massageEditorModel.Description;

            return true;
        }
    }
}
