using Phoenix.DAL.Entityes;
using Phoenix.ViewModels;
using Phoenix.ViewModels.EntityViewModel;
using Phoenix.Views.Windows;
using System.Collections.ObjectModel;

namespace Phoenix.Services
{
    internal class MasterDialogService : UserDialog<Master>
    {
        /// <summary>
        /// Opening the agg and edit window, setting the entered values for the master
        /// </summary>
        /// <param name="entity">Master</param>
        /// <param name="entityCollection">Masters collection</param>
        /// <returns>bool</returns>
        public override bool ShowEditWindow(Master entity, ObservableCollection<Master> mastersCollection)
        {
            var masterEditorModel = new MasterEditorViewModel(entity);

            var masterEditorWindow = new MasterEditorWindow(
                );

            return true;
        }
    }
}
