using CRUD_API.Model;
using CRUD_API.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomeErrorResponseViewModel>().HasNoKey();
        }

        //Model
        public DbSet<Employee> Employee { get; set; }

        //ViewModel
        public DbSet<CustomeErrorResponseViewModel> CustomeErrorResponseViewModel { get; set; }

    }
}
