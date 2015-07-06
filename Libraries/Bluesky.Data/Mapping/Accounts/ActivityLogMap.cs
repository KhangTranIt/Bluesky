using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Accounts;

namespace Bluesky.Data.Mapping.Accounts
{
    public class ActivityLogMap : EntityTypeConfiguration<ActivityLog>
    {
        public ActivityLogMap()
        {
            this.ToTable("ActivityLog");
            this.HasKey(c => c.Id);

            this.HasRequired(d => d.Account)
                .WithMany()
                .HasForeignKey(d => d.AccountId);
        }
    }
}
