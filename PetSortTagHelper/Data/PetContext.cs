using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetSortTagHelper.Models;

namespace PetSortTagHelper.Data
{
    public class PetContext:DbContext
    {
        public PetContext(DbContextOptions options):base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Graft> Grafts { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
    }
}
