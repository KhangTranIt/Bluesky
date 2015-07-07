using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Clients
{
    public class MappingClientProviders : BaseEntity
    {
        public int ClientID { get; set; }
        public int ProviderID { get; set; }
      
    }
}
