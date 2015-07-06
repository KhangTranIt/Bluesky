using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bluesky.Admin.Models.Bank
{
    public class BankModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [DisplayName("Bank Name")]
        [UIHint("TextboxEditor")]
        public string Name { get; set; }

        [DisplayName("Bank Account No.")]
        [UIHint("TextboxEditor")]
        public string BankAccNo { get; set; }

        [DisplayName("Remark")]
        [DataType(DataType.MultilineText)]
        [UIHint("Textarea")]
        public string Remark { get; set; }

        [DisplayName("Update by")]
        public string UpdateBy { get; set; }

        [DisplayName("Update on")]
        public DateTime UpdateOn { get; set; }
    }
}