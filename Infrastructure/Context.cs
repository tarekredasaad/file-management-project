using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Constants;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        { }

        public DbSet<Documents> Documents { get; set; }
        public DbSet<Priorities> Priorities { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ApplicationUser>().HasIndex(u=>u.Email).IsUnique();
            
        }
    }
}
