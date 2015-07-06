using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public interface IActivityLogService
    {
        ActivityLog GetActivityLogById(int activityLogId);
        IEnumerable<ActivityLog> GetAllActivityLog();
        void InsertActivityLog(ActivityLog activityLog);
        void UpdateActivityLog(ActivityLog activityLog);
        void DeleteActivityLog(ActivityLog activityLog);
    }
}
