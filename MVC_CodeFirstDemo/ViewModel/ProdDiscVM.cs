using System.ComponentModel.DataAnnotations;

namespace MVC_CodeFirstDemo.ViewModel
{
    public class ProdDiscVM
    {
        [Display(Name ="Product Id")]
        public int ProdId {  get; set; }
        [Display(Name = "Product Name")]
        public string ProdName { get; set; }
        [Display(Name = "Product Price")]
        public double ProdPrice { get; set; }
        [Display(Name = "Category")]
        public string CatCode { get; set; }
        public string Color {  get; set; }
    }
}
