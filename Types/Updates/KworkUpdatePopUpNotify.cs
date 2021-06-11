using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types.Updates
{
    public class KworkUpdatePopUpNotify
    {
        public string id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string url { get; set; }
        public int sourceAppId { get; set; }
        public string usernameFrom { get; set; }
        public KworkUpdatePopUpNotifyBadge badge { get; set; }
    }
}
