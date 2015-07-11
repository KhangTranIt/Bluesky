using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Clients;
using Bluesky.Core.Domain.Sites;
using Bluesky.Core.Domain.UserRoles;

namespace Bluesky.Data.Mapping.Sites
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("UserRoleMap");
            this.HasKey(c => c.User_Role_ID);
        }
    }
}
