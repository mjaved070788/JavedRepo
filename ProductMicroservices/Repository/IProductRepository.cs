using ProductMicroservices.Models;
namespace ProductMicroservices.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetProductById(int ProductId);
        void InsertProduct(Product Product);
        void UpdateProduct(Product Product);
        void DeleteProduct(int ProductId);
        void Save();

    }
}
