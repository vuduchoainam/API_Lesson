using Lessonapi.Data;
using Lessonapi.Models;

namespace Lessonapi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public CategoryVM Add(CategoryModel category)
        {
            var _category = new Category
            {
                Name = category.Name,
            };
            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryVM
            {
                CategoryId = _category.CategoryId,
                Name = category.Name
            };
        }

        public void Delete(int id)
        {
            var category = _context.categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }

        public void Edit(int id, CategoryModel model)
        {
            var _category = _context.categories.SingleOrDefault(c => c.CategoryId == id);
            if (_category != null)
            {
                _category.Name = model.Name;
                _context.SaveChanges();
            }
        }

        public void Edit(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public void Edit(CategoryVM category)
        {
            throw new NotImplementedException();
        }

        public List<CategoryVM> GetAll()
        {
            var categories = _context.categories.Select(c => new CategoryVM
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
            });
            return categories.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var category = _context.categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                return new CategoryVM
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                };
            }
            return null;
        }
    }
}
