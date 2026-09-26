using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.Entities;

namespace BOMProject.DataAccess.Repositories
{
    public interface IActivityLogRepository
    {
        void AddActivityLog(ActivityLog activityLog);
        List<ActivityLog> GetAllActivityLogs();
        void SaveChanges();
    }
}
