using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace Bluesky.Core.Domain.Accounts
{
    public class Account : BaseEntity
    {
        private ICollection<AccountRole> _accountRoles;

       
     

        public Guid AccountGuid { get; set; }
        public bool Deleted { get; set; }
        public bool Active { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Contact { get; set; }

        public string Language { get; set; }

        public DateTime? Birthdate { get; set; }

        public string Country { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankBranch { get; set; }
        public int UserBankTypeId { get; set; }
        public string Email { get; set; }
        public bool RecivedSMS { get; set; }
        public string Game1 { get; set; }
        public string GameUsername1 { get; set; }
        public string Game2 { get; set; }
        public string GameUsername2 { get; set; }
        public string Game3 { get; set; }
        public string GameUsername3 { get; set; }
        public string Game4 { get; set; }
        public string GameUsername4 { get; set; }
        public string Game5 { get; set; }
        public string GameUsername5 { get; set; }
        public string Comment { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime LastActivityDateUtc { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        /// <summary>
        /// Gets or sets the password format
        /// </summary>
        public int PasswordFormatId { get; set; }
        /// <summary>
        /// Gets or sets the password format
        /// </summary>
        public PasswordFormat PasswordFormat
        {
            get { return (PasswordFormat)PasswordFormatId; }
            set { this.PasswordFormatId = (int)value; }
        }
        /// <summary>
        /// Gets or sets the customer roles
        /// </summary>
        public virtual ICollection<AccountRole> AccountRoles
        {
            get { return _accountRoles ?? (_accountRoles = new List<AccountRole>()); }
            protected set { _accountRoles = value; }
        }
    }
}
