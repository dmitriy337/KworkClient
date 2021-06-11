using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class Kwork
    {
        public long id { get; set; }
        public int category_id { get; set; }
        public int status_id { get; set; }
        public int price { get; set; }
        public int profile_sort { get; set; }

        public bool is_price_from { get; set; }
        public bool is_from { get; set; }
        public bool is_best { get; set; }
        public bool is_hidden { get; set; }
        public bool is_favorite { get; set; }
        
        public bool isSubscription { get; set; }

        public string category_name { get; set; }
        public string status_name { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string photo { get; set; }
        public string lang { get; set; }

        public KworkCover cover { get; set; }
        public KworkWorker worker { get; set; }
        public KworkActivity activity { get; set; }

    }
}
