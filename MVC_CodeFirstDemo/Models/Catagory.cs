using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirstDemo.Models
{
    //[Table("CF_Category")]
    public class Catagory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatId {  get; set; }
        [Required(ErrorMessage="Category Code Required")]
        [StringLength(10)]
        [Display(Name = "Category Code")]
        public string? CatCode { get; set; }
        [Required(ErrorMessage = "Category Desc Required")]
        [StringLength(20)]
        [Display(Name ="Category Description")]
        public string? CatDesc { get; set; }=null!;

        public virtual ICollection<Product>? Prods { get; set; }
    }
}
