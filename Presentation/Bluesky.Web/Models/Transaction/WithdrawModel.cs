using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bluesky.Web.Models.Transaction
{
    public class WithdrawModel
    {
        public WithdrawModel()
        {
            Products = new List<SelectListItem>();
        }
        public int Id { get; set; }
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Product")]
        [Required(ErrorMessage = "Please choose a product.")]
        public int ProductId { get; set; }
        public List<SelectListItem> Products { get; set; }

        [DisplayName("Bank")]
        [Required(ErrorMessage = "Bank Name is required.")]
        public string UserBankName { get; set; }

        [DisplayName("Bank Account No.")]
        [Required(ErrorMessage = "Bank Account number is required.")]
        public string UserBankAccNo { get; set; }
    }
}