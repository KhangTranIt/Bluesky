using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bluesky.Web.Models.Transaction
{
    public class TransferModel
    {
        public TransferModel()
        {
            Products = new List<SelectListItem>();
        }
        public int Id { get; set; }
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [DisplayName("Product")]
        [Required(ErrorMessage = "Please choose a product.")]
        public int ProductFromId { get; set; }

        [DisplayName("To")]
        [Required(ErrorMessage = "Please choose a product.")]
        public int ProductToId { get; set; }
        public List<SelectListItem> Products { get; set; }
    }
}