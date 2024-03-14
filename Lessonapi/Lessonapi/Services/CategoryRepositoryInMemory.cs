using Lessonapi.Models;

namespace Lessonapi.Services
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryVM> categoryVMs = new List<CategoryVM>()
        {
            new CategoryVM{CategoryId = 1 , Name = "Tivi"},
            new CategoryVM{CategoryId = 2 , Name = "Tủ lạnh"},
            new CategoryVM{CategoryId = 3 , Name = "Máy lạnh"},
            new CategoryVM{CategoryId = 4 , Name = "Máy giặt"},
        };
        public CategoryVM Add(CategoryModel model)
        {
            var _categoryVM = new CategoryVM
            {
                CategoryId = categoryVMs.Max(c => c.CategoryId) + 1,
                Name = model.Name
            };
            categoryVMs.Add(_categoryVM);
            return _categoryVM;
        }
        

        public void Delete(int id)
        {
            var _categoryVM = categoryVMs.SingleOrDefault(c => c.CategoryId == id);
            categoryVMs.Remove(_categoryVM);
        }

        public void Edit(int id, CategoryModel model)
        {
            var _categoryVM = categoryVMs.SingleOrDefault(c => c.CategoryId == id);
            if(_categoryVM == null)
            {
                _categoryVM.Name = model.Name;
            }    
        }

        public List<CategoryVM> GetAll()
        {
            return categoryVMs;
        }

        public CategoryVM GetById(int id)
        {
            return categoryVMs.SingleOrDefault(c => c.CategoryId == id);
        }
    }
}
