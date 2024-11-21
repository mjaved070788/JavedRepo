using Microsoft.EntityFrameworkCore;
using ProductMicroservices.DBContexts;
using ProductMicroservices.Repository;
using ProductMicroservices.Models;

namespace ProductMicroservices.Repository
{
    public class CategoriesRepository : ICategoryRepository
    {
        private readonly ProductContext _dbContext;

        public CategoriesRepository(ProductContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void DeleteCategory(int CategoryId)
        {
            var category = _dbContext.Categories.Find(CategoryId);
            _dbContext.Categories.Remove(category);
            Save();
        }

        public IEnumerable<Categories> GetCategory()
        {
            return _dbContext.Categories.ToList();
        }       

        public void InsertCategory(Categories Category)
        {
            _dbContext.Add(Category);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Categories Category)
        {
            _dbContext.Entry(Category).State = EntityState.Modified;
            Save();
        }

        public Categories GetCategoryById(int CategoryId)
        {
            return _dbContext.Categories.Find(CategoryId);
        }
    }
}
