using api_base.Interface;
using api_base.Models;
using api_base.Data;

namespace api_base.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public CategoryRepository (DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public Category CreateCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category DeleteCategory(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(p => p.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public Category UpdateCategory(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}