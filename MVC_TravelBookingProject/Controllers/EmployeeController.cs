using Microsoft.AspNetCore.Mvc;
using MVC_TravelBookingProject.Repository;
using MVC_TravelBookingProject.Models;

namespace MVC_TravelBookingProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _emR;
        public EmployeeController(IEmployeeRepository emR)
        {
            _emR = emR;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> employees=_emR.GetAllEmployees();
            return View(employees);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee e)
        {

            if (ModelState.IsValid)
            {
                //Console.WriteLine("In Add  product" + p.Name);
                _emR.AddEmployee(e);
            }
            return RedirectToAction("Index");
        }

    }
}
