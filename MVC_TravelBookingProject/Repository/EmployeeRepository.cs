using MVC_TravelBookingProject.Models;

namespace MVC_TravelBookingProject.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        public static List<Employee> lstemployees { get; set; } = new List<Employee>()
         {
                new Employee() { empId = 1, empFname = "Vidya", empLName = "Mane", empAddress = "Pune", empContactNo = "8605679406", empDob = DateTime.Parse("07-05-1990") },
                new Employee() { empId = 2, empFname = "Akansha", empLName = "Bhagat", empAddress = "Pune", empContactNo = "9156576787", empDob = DateTime.Parse("07-05-1990") },
                new Employee() { empId = 3, empFname = "Suhani", empLName = "Gaikwad", empAddress = "Pune", empContactNo = "9156576787", empDob = DateTime.Parse("07-05-1990") },
                new Employee() { empId = 4, empFname = "Akansha", empLName = "Bhagat", empAddress = "Pune", empContactNo = "9156576787", empDob = DateTime.Parse("07-05-1990") },
                new Employee() { empId = 5, empFname = "Sakshi", empLName = "Banakar", empAddress = "Pune", empContactNo = "9156576787", empDob = DateTime.Parse("07-05-1990") }
          };
        public IEnumerable<Employee> GetAllEmployees()
        {
            return lstemployees;
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    lstemployees.Add(employee);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.ToString()}");
            }

        }
        public void DeleteProduct(int id)
        {
            try
            {
                Employee e = lstemployees.FirstOrDefault(x => x.empId == id);
                int index = lstemployees.IndexOf(e);
                lstemployees.RemoveAt(index);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error:{e.ToString()}");
            }
        }
        //public Employee GetEmpByID(int empId)
        //{
        //    Console.WriteLine("In Get Employee by Id - DAL");
        //    Employee Emp = lstemployees.FirstOrDefault(emp1 => emp1.empId == empId);
        //    if (empId != null)
        //    {
        //        return Emp;
        //    }
        //    return null;
        //}
        //public void EditEmployee(Employee emp)
        //{
        //    Console.WriteLine("In Edit - DAL");
        //    Employee updateEmp = lstemployees.FirstOrDefault(x => x.empId == emp.empId);
        //    int index = lstemployees.IndexOf(updateEmp);
        //    if (updateEmp != null)
        //    {

        //        lstemployees[index].empFname = emp.empFname;
        //        lstemployees[index].empLName = emp.empLName;
        //        lstemployees[index].empAddress = emp.empAddress;
        //        lstemployees[index].empContactNo = emp.empContactNo;
        //        lstemployees[index].empDob = emp.empDob;

        //    }

        //}
        //public void ViewAllEmployee()
        //{
        //    Console.WriteLine("--------------------------------------------------------------------------------------------------");
        //    Console.WriteLine("                                          View All Employees");
        //    Console.WriteLine("--------------------------------------------------------------------------------------------------");
        //    Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-18} {4,-20} {5,-20}", "EmpId", "FName", "LName", "Address", "Contact", "DOB");
        //    Console.WriteLine("--------------------------------------------------------------------------------------------------");
        //    foreach (Employee employee in lstemployees)
        //    {
        //        Console.WriteLine(employee.ToString());

        //    }

        //}
        //public int DeleteEmployee(int empId)
        //{
        //    try
        //    {
        //        Console.WriteLine("In delete -DAL");
        //        var empD = lstemployees.Remove(lstemployees.FirstOrDefault(emp => emp.empId == empId));
        //        Console.WriteLine("Employee with Id {0} is deleted!!!", empId);
        //        ViewAllEmployee();
        //    }
        //    catch (FormatException ex) { Console.WriteLine(ex.Message); }
        //    return 1;
        //}

    }
}
