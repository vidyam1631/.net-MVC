using Microsoft.AspNetCore.Mvc;
using MVC_DBFirstDemo.Repository;
using MVC_DBFirstDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_DBFirstDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _prodrepo;
        private readonly ICatagoryRepository _catrepo;
        public ProductController(IProductRepository prodrepo, ICatagoryRepository catrepo)
        {
            _prodrepo = prodrepo;
            _catrepo = catrepo;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> products= _prodrepo.GetProducts();
            return View(products);
        }

        public IActionResult AddProduct()
        {
            ViewBag.Catagories = new SelectList(_catrepo.GetCatagories(), "CatId", "CatCode");
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            if(p!=null)
            {
               _prodrepo.AddProduct(p);
            }return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id) {
            if(id!=null)
            {
                _prodrepo.DeleteProduct(id);
            }return RedirectToAction("Index");
        }
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Catagories = new SelectList(_catrepo.GetCatagories(), "CatId", "CatCode");
            Product? product=_prodrepo.GetProductById(id);
            return View(product);
        }
        [HttpPost]
            public IActionResult UpdateProduct(Product product, int id) {
            if (ModelState.IsValid)
            {
                _prodrepo.UpdateProduct(product,id);
            }
            return RedirectToAction("Index");
        }
    }
}
