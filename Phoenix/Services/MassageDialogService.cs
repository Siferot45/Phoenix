using Phoenix.DAL.Entityes;
using Phoenix.Services.Interfaces;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;
using System.Collections.ObjectModel;

namespace Phoenix.Services
{
    /// <summary>
    /// Переопределение окна диалога для массажа
    /// </summary>
    internal class MassageDialogService : UserDialog<Massage>
    {
        /// <summary>
        /// Вызов окна добавления и редактирования, установка ранние в веденых значений для массажа
        /// </summary>
        public override bool ShowEditWindow(Massage massage, ObservableCollection<Massage> massagesCollection)
        { 
            var massageAddModel = new MassageEditorViewModel(massage, massagesCollection);

            var massageEditorWindow = new MassageEditorWindow
            {
                DataContext = massageAddModel
            };

            if (massageEditorWindow.ShowDialog() != true)
                return false;

            massage.Name = massageAddModel.Name;
            //massage.Category = new Category { Name = massageAddModel.Category };
            massage.Duration = massageAddModel.Duration;
            massage.Description = massageAddModel.Description;

            return true;
        }
    }
}
