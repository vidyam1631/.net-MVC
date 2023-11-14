using Microsoft.AspNetCore.Mvc;
using MVC_DBFirstDemo.Repository;
using MVC_DBFirstDemo.Models;
namespace MVC_DBFirstDemo.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ICatagoryRepository _catrepo;
        public CatagoryController(ICatagoryRepository categoryRepository)
        {
            _catrepo = categoryRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Catagory> catagories=_catrepo.GetCatagories();
            return View(catagories);
        }
        public IActionResult AddCatagory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCatagory(Catagory c) { 
           if(ModelState.IsValid)
            {
                _catrepo.AddCatagory(c);
            }return RedirectToAction("Index");
        }
        public IActionResult DeleteCatagory(int id)
        {
            if (id != null)
            {
                _catrepo.DeleteCatagory(id);
            }
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCatagory(int id)
        {
            Catagory cat=_catrepo.GetCatagoryByid(id);

            return View(cat);
        }
        [HttpPost]
        public IActionResult UpdateCatagory(int id, Catagory c)
        {
            if (ModelState.IsValid)
            {
                _catrepo.UpdateCatagory(id,c);
            }
            return RedirectToAction("Index");
            
        }
    }
}
