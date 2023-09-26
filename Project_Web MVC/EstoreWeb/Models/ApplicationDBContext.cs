using EStoreWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstoreWeb.Models
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                    new Category {Id = 1, Name = "Điện thoại", DisplayOrder = 1},
                    new Category { Id = 2, Name = "Laptop Gamming", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "Phụ kiện", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "iOphon 11 ", ChuThich= "Màu Xanh",Gia = 190000, ImageUrl = "VS.png", CategoryId = 2},
                    new Product { Id = 2, Name = "iOphon 11 ", ChuThich = "Màu Xanh", Gia = 190000, ImageUrl = "VS.png", CategoryId = 1 },
                    new Product { Id = 3, Name = "iOphon 11 ", ChuThich = "Màu Xanh", Gia = 190000, ImageUrl = "VS.png", CategoryId = 3 }
                );
        }
        // seed data 

    }
}
