using MVC_DBFirstDemo.Models;

namespace MVC_DBFirstDemo.Repository
{
    public class CatagoryRepository:ICatagoryRepository
    {
        private readonly db_classDemoContext _context;
        public CatagoryRepository(db_classDemoContext context)
        {
            _context = context;
        }
        public IEnumerable<Catagory> GetCatagories()
        {
            return _context.Catagories;
        }
        public void AddCatagory(Catagory c)
        {
            if (c != null)
            {
                _context.Catagories.Add(c);
                _context.SaveChanges();

            }
           
        }
        public void DeleteCatagory(int id)
        {
            if (id != null)
            {
                Catagory? cat = _context.Catagories.FirstOrDefault(c => c.CatId == id);
                if (cat != null)
                {
                    _context.Catagories.Remove(cat);
                    _context.SaveChanges();
                }
                
            }
        }
        
        public Catagory GetCatagoryByid(int id)
        {
            Catagory c=_context.Catagories.FirstOrDefault(x=>x.CatId == id);
            return c;
        }
        public void UpdateCatagory(int id, Catagory c)
        {
            Catagory? cat_old = _context.Catagories.FirstOrDefault(c => c.CatId == id);
            if (cat_old != null)
            {
                cat_old.CatCode = c.CatCode;
                cat_old.CatDesc = c.CatDesc;
                _context.SaveChanges();
            }
        }
    }
}
