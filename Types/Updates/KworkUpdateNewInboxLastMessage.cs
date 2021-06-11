using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types.Updates
{
    public class KworkUpdateNewInboxLastMessage
    {
        public bool unread { get; set; }
        public string fromUsername { get; set; }
        public int fromUserId { get; set; }
        public string type { get; set; }
        public int time { get; set; }
        public string message { get; set; }
        public string profilePicture { get; set; }
    }
}
