using MVC_DBFirstDemo.Models;

namespace MVC_DBFirstDemo.Repository
{
    public interface IProductRepository
    {
         IEnumerable<Product> GetProducts();
         void AddProduct(Product product);
         void UpdateProduct(Product product, int id);
        Product GetProductById(int id);
        void DeleteProduct(int id);
    }
}
