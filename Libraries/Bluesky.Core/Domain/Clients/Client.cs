using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Clients
{
    public class Client : BaseEntity
    {
        public int ClientID { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientAddressLine1 { get; set; }
        public string ClientAddressLine2 { get; set; }
        public string ClientCity { get; set; }
        public string ClientState { get; set; }
        public string ClientCountry { get; set; }
        public string ClientPostCode { get; set; }
        public string ClientBusinessName { get; set; }
    }
}
