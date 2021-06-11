using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkDialog
    {
        public int unread_count { get; set; }
        public string last_message { get; set; }
        public int time { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public string profilepicture { get; set; }
        public bool is_online { get; set; }
        public int lastOnlineTime { get; set; }
        public string link { get; set; }
        public string status { get; set; }
        public KworkDialogLastMessage lastMessage { get; set; }
        public bool blocked_by_user { get; set; }
        public bool allowedDialog { get; set; }
        public bool has_active_order { get; set; }
        public bool archived { get; set; }
        public bool isStarred { get; set; }
        public string warning_message_id { get; set; }
        public int countup { get; set; }
        public bool has_answer { get; set; }
        public bool is_allow_custom_request { get; set; }
        public int hidden_at { get; set; }
    }
}
