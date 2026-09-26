using System;
using Microsoft.EntityFrameworkCore;
using BOMProject.Entities;

namespace BOMProject.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Material> Materials { get; set; } = null!;
        public DbSet<ImportHistory> ImportHistories { get; set; } = null!;
        public DbSet<ActivityLog> ActivityLogs { get; set; } = null!;
    }
}
