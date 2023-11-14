using Microsoft.EntityFrameworkCore;
using MVC_DBFirstDemo.Models;
using MVC_DBFirstDemo.Repository;

namespace MVC_DBFirstDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<db_classDemoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));
            builder.Services.AddScoped<ICatagoryRepository, CatagoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}