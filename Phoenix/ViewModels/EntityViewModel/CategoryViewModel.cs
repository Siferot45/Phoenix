using Phoenix.DAL.Entityes;
using Phoenix.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.ViewModels.EntityViewModel
{
    class CategoryViewModel
    {
        private readonly IRepository<Category> _categoryRepository;
        public CategoryViewModel(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<Category> CategoryCollection { get; set; }
        public void GetNameCategories() 
        {
            CategoryCollection = new List<Category>(_categoryRepository.Items.ToArray());
        }
    }
}
