using MVC_DBFirstDemo.Models;

namespace MVC_DBFirstDemo.Repository
{
    public interface ICatagoryRepository
    {
        IEnumerable<Catagory> GetCatagories();
        public void AddCatagory(Catagory c);
        public void DeleteCatagory(int id);
        public void UpdateCatagory(int id, Catagory c);
        public Catagory GetCatagoryByid(int id);
    }
}
