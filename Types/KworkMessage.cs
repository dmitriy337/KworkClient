using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkMessage
    {
        public int message_id { get; set; }
        public int to_id { get; set; }
        public string to_username { get; set; }
        public int to_live_date { get; set; }
        public int from_id { get; set; }
        public string from_username { get; set; }
        public int from_live_date { get; set; }
        public string from_profilepicture { get; set; }
        public string to_profilepicture { get; set; }
        public string message { get; set; }
        public int time { get; set; }
        public bool unread { get; set; }
        public string status { get; set; }
        public object type { get; set; }
        public object created_order_id { get; set; }
        public bool forwarded { get; set; }
        public object updated_at { get; set; }
        public string warning_type { get; set; }
        public int countup { get; set; }
        public KworkMessageFile[] files { get; set; }
    }
}
