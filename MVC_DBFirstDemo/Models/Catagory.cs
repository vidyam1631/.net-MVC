using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_DBFirstDemo.Models
{
    public partial class Catagory
    {
        public Catagory()
        {
            Products = new HashSet<Product>();
        }

        public int CatId { get; set; }
        [Required(ErrorMessage ="Category Code Required")]
        [MaxLength(20,ErrorMessage="Code Length less than or equal to 20")]
        public string? CatCode { get; set; }
        [Required(ErrorMessage = "Category Desc Required")]
        public string CatDesc { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
