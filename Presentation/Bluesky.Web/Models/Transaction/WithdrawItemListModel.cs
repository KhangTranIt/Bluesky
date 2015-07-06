using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bluesky.Web.Models.Transaction
{
    public class WithdrawItemListModel
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public DateTime TransDateTime { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public string UserBankName { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
    }
}