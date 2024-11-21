using ProductMicroservices.Models;

namespace ProductMicroservices.Repository
{
    public interface ICategoryRepository
    {

        IEnumerable<Categories> GetCategory();

        Categories GetCategoryById(int CategoryId);
        void InsertCategory(Categories Category);
        void UpdateCategory(Categories Category);
        void DeleteCategory(int CategoryId);
        void Save();
    }
}
