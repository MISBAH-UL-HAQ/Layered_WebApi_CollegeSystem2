using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Infrastructure.Data
{
    //    public class AppDbContext : IdentityDbContext<RegisterUser>
    //    {
    //        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //        public DbSet<Department> Departments { get; set; }
    //        public DbSet<Student> Students { get; set; }

    //        public DbSet<RegisterUser> Users { get; set; }
    //    }
    //}

    public class AppDbContext : IdentityDbContext<RegisterUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}


//    public class AppDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

//        public DbSet<Department> Departments { get; set; }
//        public DbSet<Student> Students { get; set; }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            base.OnModelCreating(builder);
//            // Configure foreign key relationship
//            builder.Entity<ApplicationUser>()
//                .HasOne(u => u.Department)
//                .WithMany()
//                .HasForeignKey(u => u.DepartmentId);
//        }
//    }
//}