using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Banks;

namespace Bluesky.Data.Mapping.Banks
{
    public class BankMap : EntityTypeConfiguration<Bank>
    {
        public BankMap()
        {
            this.ToTable("Bank");
            this.HasKey(c => c.Id);
        }
    }
}
