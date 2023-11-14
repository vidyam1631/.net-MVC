using MVC_CodeFirstDemo.Models;

namespace MVC_CodeFirstDemo.Repositrory
{
    public interface ICatagoryRepository
    {
        IEnumerable<Catagory> GetCatagories();
        void AddCatagory(Catagory catagory);
    }
}
