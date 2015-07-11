using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bluesky.Core.Domain.Clients;
using Bluesky.Core.Domain.Sites;
using Bluesky.Core.Domain.Users;

namespace Bluesky.Data.Mapping.Users
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Users");
            this.HasKey(c => c.User_ID);
        }
    }
}
