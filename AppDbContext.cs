using System;
using microsoft.EntityFrameworkCore;
using BOMProject.Entities;

namespace bomApp.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Material> Materials { get; set; }
    }
}
