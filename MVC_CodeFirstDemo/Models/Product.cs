using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_CodeFirstDemo.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdId { get; set; }
        public string? ProdName { get; set; }
        [Range(100,100000,ErrorMessage ="Product price to be between 100 to100000")]
        public double ProdPrice { get; set; }
        [ProdDateCheck(ErrorMessage="Product Date to be greater than today")]
        public DateTime ProdDate { get; set; }

        public int? CatId { get; set; }

        public virtual Catagory? Cat { get; set; }
    }
}
