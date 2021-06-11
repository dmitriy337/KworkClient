using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkUser
    {
        public long id { get; set; }

        public string username { get; set; }
        public string status { get; set; }
        public string fullname { get; set; }
        public string profilepicture { get; set; }
        public string description { get; set; }
        public string slogan { get; set; }
        public string location { get; set; }
        public string level_description { get; set; }
        public string specialization { get; set; }
        public string profession { get; set; }
        public string cover { get; set; }


        public decimal rating(string s) => decimal.Parse(s);

        public decimal rating_count { get; set; }
        public decimal good_reviews { get; set; }
        public decimal bad_reviews { get; set; }
        public decimal reviews_count { get; set; }
        public decimal live_date { get; set; }

        public bool online { get; set; }
        public bool blocked_by_user { get; set; }
        public bool allowedDialog { get; set; }
        public object portfolio_list { get; set; }


        public int kworks_count { get; set; }
        public int custom_request_min_budget { get; set; }
        public int order_done_persent { get; set; }
        public int order_done_intime_persent { get; set; }
        public int order_done_repeat_persent { get; set; }
        public int timezoneId { get; set; }
        public int completed_orders_count { get; set; }

        public long addtime { get; set; }

        public Kwork[] kworks { get; set; }
        public KworkReviews[] reviews { get; set; }

    }
}
