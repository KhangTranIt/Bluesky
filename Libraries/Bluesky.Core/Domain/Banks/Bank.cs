using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Banks
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
        public string BankAccNo { get; set; }
        public string Remark { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
