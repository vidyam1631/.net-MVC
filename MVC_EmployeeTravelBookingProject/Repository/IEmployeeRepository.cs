using MVC_EmployeeTravelBookingProject.Models;

namespace MVC_EmployeeTravelBookingProject.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        //void AddEmployee(Employee e);
        //void DeleteEmployee(int id);
        //Employee GetEmployeeByid(int id);
        //void UpdateEmployee(int id, Employee e);
        //Employee GetEmpByID(int empId);
        //void EditEmployee(Employee employee);
        //void ViewAllEmployee();
        //int DeleteEmployee(int empId);
    }
}
