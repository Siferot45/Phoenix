using Phoenix.DAL.Entityes;
using Phoenix.ViewModels;
using Phoenix.Views.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
            var massageAddModel = new MassageEditorViewModel(massage);

            var massageEditorWindow = new MassageEditorWindow
            {
                DataContext = massageAddModel
            };

            if (massageEditorWindow.ShowDialog() != true)
                return false;

            massage.Name = massageAddModel.Name;
            massage.Category = new Category { Name = massageAddModel.Category };
            massage.Duration = massageAddModel.Duration;
            massage.Description = massageAddModel.Description;

            return true;
        }
        public override bool Add(Massage massage, List<string> categoriesName)
        {
            var massageAddModel = new MassageEditorViewModel(massage, categoriesName);

            var massageEditorWindow = new MassageEditorWindow
            {
                DataContext = massageAddModel
            };

            if (massageEditorWindow.ShowDialog() != true)
                return false;

            massage.Name = massageAddModel.Name;
            massage.Category = new Category { Name = massageAddModel.Category };
            massage.Duration = massageAddModel.Duration;
            massage.Description = massageAddModel.Description;

            return true;
        }
    }
}
