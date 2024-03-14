using Lessonapi.Models;

namespace Lessonapi.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Add(CategoryModel model);
        void Edit(int id, CategoryModel model);
        void Delete(int id);
    }
}
