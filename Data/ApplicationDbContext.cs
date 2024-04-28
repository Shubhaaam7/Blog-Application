


using BlogApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace  BlogApplication.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        { }

       public  DbSet<Blog> BlogDetails { get; set; }
        public DbSet<Dashboard> SalesMontlyData { get; set; }
    }
}
