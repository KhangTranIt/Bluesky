using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Clients;

namespace Bluesky.Data.Mapping.Clients
{
    public class MappingClientProviderMap : EntityTypeConfiguration<MappingClientProvider>
    {
        public MappingClientProviderMap()
        {
            this.ToTable("MappingClientProviders");
         
        }
    }
}
