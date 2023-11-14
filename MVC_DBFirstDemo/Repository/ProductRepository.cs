using Microsoft.EntityFrameworkCore;
using MVC_DBFirstDemo.Models;

namespace MVC_DBFirstDemo.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly db_classDemoContext _context;
        public ProductRepository(db_classDemoContext prodrepo)
        {
            _context = prodrepo;
        }
        public IEnumerable<Product> GetProducts() {
            IEnumerable<Product> products = _context.Products.Include(x=>x.Cat);
            return products;
        }
        public void AddProduct(Product product)
        {
            if(product != null)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }
        public Product GetProductById(int id)
        {
            Product? product = _context.Products.FirstOrDefault(x => x.ProId == id);
            
                return product;
           
        }
        public void UpdateProduct(Product product, int id)
        {
            Product? p = _context.Products.FirstOrDefault(x => x.ProId == id);
            if(p != null)
            {
                p.ProdName = product.ProdName;
                p.ProPrice = product.ProPrice;
                p.CatId = product.CatId;
                _context.SaveChanges();
            }
        }
        public void DeleteProduct(int id)
        {
            Product? product = _context.Products.FirstOrDefault(x => x.ProId == id);
            if(product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            
        }
    }
}
