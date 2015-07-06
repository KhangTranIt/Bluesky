using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bluesky.Web.Models.Transaction
{
    public class DepositModel
    {
        public DepositModel()
        {
            Banks = new List<SelectListItem>();
            Channels = new List<SelectListItem>();
            Products = new List<SelectListItem>();
            Bonuses = new List<SelectListItem>();
        }
        public int Id { get; set; }
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "Please choose a bank.")]
        public int BankId { get; set; }
        public List<SelectListItem> Banks { get; set; }

        [DisplayName("Bank Reference No.")]
        [Required(ErrorMessage = "Reference number is required.")]
        public string RefNo { get; set; }

        [DisplayName("Bank In Date/Time")]
        public DateTime BankDateTime { get; set; }

        [DisplayName("Channel")]
        [Required(ErrorMessage = "Please choose a channel.")]
        public int ChannelId { get; set; }
        public List<SelectListItem> Channels { get; set; }

        [DisplayName("Product")]
        [Required(ErrorMessage = "Please choose a product.")]
        public int ProductId { get; set; }
        public List<SelectListItem> Products { get; set; }

        [DisplayName("Bonus")]
        [Required(ErrorMessage = "Please choose a bonus.")]
        public int BonusId { get; set; }
        public List<SelectListItem> Bonuses { get; set; } 
    }
}