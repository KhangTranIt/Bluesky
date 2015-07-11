using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Clients;
using Bluesky.Core.Domain.Sites;

namespace Bluesky.Data.Mapping.Sites
{
    public class SiteMap : EntityTypeConfiguration<Site>
    {
        public SiteMap()
        {
            this.ToTable("Sites");
            this.HasKey(c => c.Id);
        }
    }
}
