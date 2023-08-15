
namespace Phoenix.ViewModels
{
    internal class MainWindowViewModel 
    {
        private string _title = "Главная страница";
        public string Title
        {
            get => _title; 
            set => _title = value;
        }
    }
}
