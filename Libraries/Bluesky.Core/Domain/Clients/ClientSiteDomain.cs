using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Clients
{
    public class ClientSiteDomain : BaseEntity
    {
        public int DomainID { get; set; }
        public int ClientID { get; set; }
        public int SiteID { get; set; }
       
    }
}
