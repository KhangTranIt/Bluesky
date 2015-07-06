using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Data;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Services.Accounts
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IRepository<ActivityLog> _activityLogRepository;

        public ActivityLogService(IRepository<ActivityLog> activityLogRepository)
        {
            _activityLogRepository = activityLogRepository;
        }

        public ActivityLog GetActivityLogById(int activityLogId)
        {
            if (activityLogId == 0)
                return null;
            return _activityLogRepository.Table.FirstOrDefault(p => p.Id == activityLogId);
        }

        public IEnumerable<ActivityLog> GetAllActivityLog()
        {
            return _activityLogRepository.Table.AsEnumerable();
        }

        public void InsertActivityLog(ActivityLog activityLog)
        {
            if(activityLog == null)
                throw new ArgumentNullException("activityLog");

            _activityLogRepository.Insert(activityLog);
        }

        public void UpdateActivityLog(ActivityLog activityLog)
        {
            if (activityLog == null)
                throw new ArgumentNullException("activityLog");

            _activityLogRepository.Update(activityLog);
        }

        public void DeleteActivityLog(ActivityLog activityLog)
        {
            if (activityLog == null)
                throw new ArgumentNullException("activityLog");

            _activityLogRepository.Delete(activityLog);
        }
    }
}
