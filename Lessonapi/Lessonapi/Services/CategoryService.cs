using Lessonapi.Models;
using Lessonapi.Repository;

namespace Lessonapi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryVM Add(CategoryModel model)
        {
            return _categoryRepository.Add(model);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<CategoryVM> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public CategoryVM GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Edit(int id, CategoryModel model)
        {
            _categoryRepository.Edit(id, model);
        }
    }
}
