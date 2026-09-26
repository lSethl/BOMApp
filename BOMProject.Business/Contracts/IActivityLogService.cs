using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.Entities;

namespace BOMProject.Business.Contracts
{
    public interface IActivityLogService
    {
        void AddActivityLog(string description);
        List<ActivityLog> GetAllActivityLogs();
    }
}