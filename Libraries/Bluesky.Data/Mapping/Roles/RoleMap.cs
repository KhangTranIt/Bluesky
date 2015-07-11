using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Providers;
using Bluesky.Core.Domain.Roles;

namespace Bluesky.Data.Mapping.Roles
{
    public class RolerMap : EntityTypeConfiguration<Role>
    {
        public RolerMap()
        {
            this.ToTable("Roles");
            this.HasKey(c => c.Role_ID);
        }
    }
}
