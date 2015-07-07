using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Services
{
    public class Services : BaseEntity
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ServiceOrderType { get; set; }
        public int ServiceConfirmationType { get; set; }
        public int ServiceType { get; set; }
        public int ServiceDeliveryMethod { get; set; }
        public DateTime ServiceDailyStartTime { get; set; }
        public DateTime ServiceDailyEndTime { get; set; }
        public int ServiceOffWeekDayID { get; set; }
        public int ServiceYearlyDaysOffID { get; set; }

        public int ServiceDeliveryZipCodesID { get; set; }

        public int ServiceAccessCode { get; set; }

    }
}
