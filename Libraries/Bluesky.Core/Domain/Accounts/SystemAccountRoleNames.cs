using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bluesky.Core.Domain.Accounts
{
    public static partial class SystemAccountRoleNames
    {
        public static string Administrators { get { return "Administrators"; } }

        public static string Registered { get { return "Registered"; } }

        public static string Guests { get { return "Guests"; } }
    }
}
