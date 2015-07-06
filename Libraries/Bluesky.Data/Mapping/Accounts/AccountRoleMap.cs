using System.Data.Entity.ModelConfiguration;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Data.Mapping.Accounts
{
    public partial class AccountRoleMap : EntityTypeConfiguration<AccountRole>
    {
        public AccountRoleMap()
        {
            this.ToTable("AccountRole");
            this.HasKey(cr => cr.Id);
            this.Property(cr => cr.Name).IsRequired().HasMaxLength(255);
            this.Property(cr => cr.SystemName).HasMaxLength(255);
        }
    }
}
