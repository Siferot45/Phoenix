using Phoenix.DAL.Entityes;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

            Category w = massageAddModel.GetCategory(massageAddModel.CategoryName);

            massage.Name = massageAddModel.Name;
            massage.Category = w;
            massage.Duration = massageAddModel.Duration;
            massage.Description = massageAddModel.Description;

            return true;
        }
    }
}
