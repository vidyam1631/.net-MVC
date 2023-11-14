using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_APIFirstDemo.Models;

namespace MVC_APIFirstDemo.Data
{
    public class MVC_APIFirstDemoContext : DbContext
    {
        public MVC_APIFirstDemoContext (DbContextOptions<MVC_APIFirstDemoContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_APIFirstDemo.Models.MVC_Movie> MVC_Movie { get; set; } = default!;
    }
}
