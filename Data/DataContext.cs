
using Microsoft.EntityFrameworkCore;
using ShopNew.Models;

namespace ShopNew.Data
{
    public class DataContext : DbContext{
        public DataContext(DbContextOptions<DataContext> options): base(options){            
        }

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categorys { get; set; }
        public DbSet<User> Users { get; set; }


    }
}