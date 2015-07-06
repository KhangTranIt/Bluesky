using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Bluesky.Admin.Models.ActivityLog
{
    public class ActivityLogModel
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateOn { get; set; }

     

        public string Name { get; set; }

    }


}