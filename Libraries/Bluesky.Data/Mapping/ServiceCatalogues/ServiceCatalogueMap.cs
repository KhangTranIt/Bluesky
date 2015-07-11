using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Providers;
using Bluesky.Core.Domain.ServiceCatalogues;

namespace Bluesky.Data.Mapping.ServiceCatalogues
{
    public class ServiceCatalogueMap : EntityTypeConfiguration<ServiceCatalogue>
    {
        public ServiceCatalogueMap()
        {
            this.ToTable("ServiceCatalogue");
            this.HasKey(c => c.ServiceCatalogueID);
        }
    }
}
