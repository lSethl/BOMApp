using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.DataAccess.Context;
using BOMProject.Entities;

namespace BOMProject.DataAccess.Repositories
{
    public class ActivityLogRepository : IActivityLogRepository
    {
        private readonly AppDbContext _context;

        public ActivityLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddActivityLog(ActivityLog activityLog)
        {
            _context.ActivityLogs.Add(activityLog);
        }

        public List<ActivityLog> GetAllActivityLogs()
        {
            return _context.ActivityLogs
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}