using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Admin.Models.Account
{


    public class AccountModels
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Birthday { get; set; }

        public string BankName { get; set; }

        public string CreateDate { get; set; }
    }
}
