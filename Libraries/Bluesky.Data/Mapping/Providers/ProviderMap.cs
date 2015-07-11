using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Providers;

namespace Bluesky.Data.Mapping.Providers
{
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public ProviderMap()
        {
            this.ToTable("Providers");
            this.HasKey(c => c.ProviderID);
        }
    }
}
