using System.ComponentModel.DataAnnotations;

namespace MVC_CodeFirstDemo.Models
{
    public class ProdDateCheck:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime chkdt = Convert.ToDateTime(value);
            int res = DateTime.Compare(chkdt, DateTime.Now);
            if (res > 0)
                return false;
            return true;
        }
        
    }
}
