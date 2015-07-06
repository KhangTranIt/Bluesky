using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Accounts
{
    public class ActivityLog : BaseEntity
    {
        public int Id { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }

        public string UserName { get; set; }

        public string Comment { get; set; }




        public string UpdateBy { get; set; }

        public DateTime? UpdateOn { get; set; }

        public string Name { get; set; }
    }
}
