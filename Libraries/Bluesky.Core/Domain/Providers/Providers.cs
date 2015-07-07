using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Providers
{
    public class Providers : BaseEntity
    {
        public int ProviderID { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }
        public string ProviderAddressLine1 { get; set; }
        public string ProviderAddressLine2 { get; set; }
        public string ProviderCity { get; set; }
        public string ProviderState { get; set; }
        public string ProviderCountry { get; set; }
        public string ProviderPostCode { get; set; }
        public string ProviderBusinessName { get; set; }
    }
}
