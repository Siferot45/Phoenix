using Phoenix.DAL.Entityes;
using Phoenix.Interfaces;
using Phoenix.ViewModels.EntityViewModel.Base;
using System.Collections.ObjectModel;

namespace Phoenix.ViewModels.EntityViewModel
{
    class MassageViewModel : ViewModelBase
    {
        private readonly IRepository<Massage> _massageRepository;

        public MassageViewModel(IRepository<Massage> massageRepository )
        {
            _massageRepository = massageRepository;
        }

        private ObservableCollection<Massage> _massages;
        public ObservableCollection<Massage> Massages
        {
            get => _massages;
            set => Set(ref _massages, value);
        }
    }
}
