using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Services;

namespace Bluesky.Data.Mapping.Services
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            this.ToTable("Services");
            this.HasKey(c => c.ServiceID);
        }
    }
}
