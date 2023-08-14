using MathCore.WPF.ViewModels;

namespace Phoenix.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "11aaa11";
        public string Title
        {
            get => _title; 
            set => Set(ref _title, value);
        }
    }
}
