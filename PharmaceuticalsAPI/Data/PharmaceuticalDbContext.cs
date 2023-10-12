using Microsoft.EntityFrameworkCore;
using PharmaceuticalsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmaceuticalsAPI.Data
{
    public class PharmaceuticalDbContext : DbContext
    {
        public PharmaceuticalDbContext(DbContextOptions<PharmaceuticalDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Models.Attribute> Attributes { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
