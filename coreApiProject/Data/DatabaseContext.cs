using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreApiProject.Entities;
namespace coreApiProject.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Todos> Todos { get; set; }
    }
}
