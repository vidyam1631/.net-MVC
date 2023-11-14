using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC_CodeFirstDemo.Models;


namespace MVC_CodeFirstDemo.Repositrory
{
    public class CatagoryRepository : ICatagoryRepository
    {
        private readonly ApplicationContext _context;
        public CatagoryRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Catagory> GetCatagories()
        {
            return _context.Catagories;
        }
        
        public void AddCatagory(Catagory catagory)
        {
            if (catagory != null)
            {
                _context.Catagories.Add(catagory);
                _context.SaveChanges();
            }
        }
    }
}
