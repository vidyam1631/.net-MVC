using MVC_TravelBookingProject.Models;
namespace MVC_TravelBookingProject.Repository
{
    public interface IEmployeeRepository
    {
        public static List<Employee> lstEmployees {  get; set; }
        public IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee e);
        void DeleteProduct(int id);
        //Employee GetEmpByID(int empId);
        //void EditEmployee(Employee employee);
        //void ViewAllEmployee();
        //int DeleteEmployee(int empId);
    }
}
