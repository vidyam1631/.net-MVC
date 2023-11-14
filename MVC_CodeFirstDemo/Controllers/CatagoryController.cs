using Microsoft.AspNetCore.Mvc;
using MVC_CodeFirstDemo.Models;
using MVC_CodeFirstDemo.Repositrory;
namespace MVC_CodeFirstDemo.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ICatagoryRepository _catRepo;

        public CatagoryController(ICatagoryRepository catRepo)
        {
            _catRepo = catRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Catagory> categories = _catRepo.GetCatagories();
            return View(categories);
        }

        public IActionResult AddCatagory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCatagory(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _catRepo.AddCatagory(catagory);
            }
            return RedirectToAction("Index");
        }

    }
}
