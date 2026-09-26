using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.Business.Contracts;
using BOMProject.DataAccess.Repositories;
using BOMProject.Entities;

namespace BOMProject.Business.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IActivityLogRepository _activityLogRepository;

        public ActivityLogService(IActivityLogRepository activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }

        public void AddActivityLog(string description)
        {
            _activityLogRepository.AddActivityLog(new ActivityLog
            {
                CreatedAt = DateTime.Now,
                Description = description
            });

            _activityLogRepository.SaveChanges();
        }

        public List<ActivityLog> GetAllActivityLogs()
        {
            return _activityLogRepository.GetAllActivityLogs();
        }
    }
}