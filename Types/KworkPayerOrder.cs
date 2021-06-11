using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkPayerOrder
    {
        public long id { get; set; }
        public long time_added { get; set; }
        public int price { get; set; }
        public string kwork_title { get; set; }
        public string display_title { get; set; }
        public long display_time { get; set; }
        public int status { get; set; }
        public string project { get; set; }
        public bool can_add_review { get; set; }
        public string cancel_reason { get; set; }
        public long kwork_id { get; set; }
        public bool can_repeat_order { get; set; }
        public int unread_tracks { get; set; }
        public bool in_work { get; set; }
        public bool is_cancel_request { get; set; }
        public bool missing_data { get; set; }
        public string photo { get; set; }
        public bool isBlackFriday { get; set; }
        public KworkPayerOrderWorker worker { get; set; }

    }
}
