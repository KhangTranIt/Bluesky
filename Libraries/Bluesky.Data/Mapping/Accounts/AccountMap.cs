using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Data.Mapping.Accounts
{
    public partial class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            this.ToTable("Account");
            this.HasKey(c => c.Id);
            this.Property(u => u.Email).HasMaxLength(1000);

            this.Ignore(u => u.PasswordFormat);

            this.HasMany(c => c.AccountRoles)
                .WithMany()
                .Map(m => m.ToTable("Account_AccountRole_Mapping"));
        }
    }
}
