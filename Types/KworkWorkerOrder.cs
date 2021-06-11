using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkWorkerOrder
    {
        public long id { get; set; }
        public long time_added { get; set; }
        public int price { get; set; }
        public string kwork_title { get; set; }
        public string display_title { get; set; }
        public object time_cancel { get; set; }
        public int status { get; set; }
        public string project { get; set; }
        public string time_left { get; set; }
        public bool in_work { get; set; }
        public long time_is_lost { get; set; }
        public bool is_cancel_request { get; set; }
        public long duration { get; set; }
        public long deadline { get; set; }
        public bool can_add_portfolio { get; set; }
        public string cancel_reason { get; set; }
        public int unread_tracks { get; set; }
        public string photo { get; set; }
        public bool isBlackFriday { get; set; }
        public KworkWorkerOrderPayer payer { get; set; }
    }
}
