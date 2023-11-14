namespace MVC_TravelBookingProject.Models
{
    public class Employee
    {
        public int empId { get; set; }
        public string empFname { get; set; }
        public string empLName { get; set; }
        public string empAddress { get; set; }
        public string empContactNo { get; set; }
        public DateTime empDob { get; set; }
      

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-10} {2,-12} {3,-15} {4,-15} {5,-20}", empId, empFname, empLName, empAddress, empContactNo, empDob);
            
        }


    }
}
