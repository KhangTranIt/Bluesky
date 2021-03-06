﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bluesky.Web.Models.Transaction
{
    public class TransferItemListModel
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransDateTime { get; set; }
        public string Email { get; set; }
        public string ProductFrom { get; set; }
        public string ProductTo { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
    }
}