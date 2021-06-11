using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types.Updates
{
    public class KworkUpdateNewInbox
    {
        public int from { get; set; }
        public string inboxMessage { get; set; }
        public int to_user_id { get; set; }
        public int inbox_id { get; set; }
        public string title { get; set; }
        public bool isCustomRequest { get; set; }
        public bool allowSound { get; set; }

        KworkUpdateNewInboxLastMessage lastMessage { get; set; }
    }
}
