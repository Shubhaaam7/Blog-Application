


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

        public virtual DbSet<MonthWiseDashboard> MonthWiseData { get; set; }

        public DbSet<Employee> Employee { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Blog>().ToTable(tb => tb.HasTrigger("TriggerName"));
        //    base.OnModelCreating(modelBuilder);
        //    this.OnModelCreating(modelBuilder);
        //}
    }
}
