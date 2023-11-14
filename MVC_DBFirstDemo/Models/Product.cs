using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MVC_DBFirstDemo.Models
{
    public partial class Product
    {
        public int ProId { get; set; }
        public string ProdName { get; set; } = null!;
        [Range(100, 1000, ErrorMessage = "Price Range varies from 100 to 100000")]
        public int ProPrice { get; set; }
        public int CatId { get; set; }

        public virtual Catagory? Cat { get; set; }
    }
}
