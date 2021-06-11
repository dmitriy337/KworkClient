using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkActor
    {
        public int id { get; set; }
        public string username { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public string type { get; set; }
        public bool verified { get; set; }
        public string profilepicture { get; set; }
        public string description { get; set; }
        public string slogan { get; set; }
        public string fullname { get; set; }
        public string level_description { get; set; }
        public string cover { get; set; }
        public int good_reviews { get; set; }
        public int bad_reviews { get; set; }
        public string location { get; set; }
        public string rating { get; set; }
        public int rating_count { get; set; }
        public int total_amount { get; set; }
        public int hold_amount { get; set; }
        public int free_amount { get; set; }
        public int inbox_archive_count { get; set; }
        public int unread_dialog_count { get; set; }
        public int notify_unread_count { get; set; }
        public bool red_notify { get; set; }
        public int warning_inbox_count { get; set; }
        public int app_notify_count { get; set; }
        public int unread_messages_count { get; set; }
        public string fullnameEn { get; set; }
        public string descriptionEn { get; set; }
        public int country_id { get; set; }
        public int city_id { get; set; }
        public int timezone_id { get; set; }
        public int addtime { get; set; }
        public bool allow_mobile_push { get; set; }
        public bool is_more_payer { get; set; }
        public int kworks_count { get; set; }
        public int favourite_kworks_count { get; set; }
        public int hidden_kworks_count { get; set; }
        public string specialization { get; set; }
        public string profession { get; set; }
        public bool kworks_available_at_weekends { get; set; }
        //achievments_list
        public int completed_orders_count { get; set; }
        public string worker_status { get; set; }
        public bool has_offers { get; set; }
        public int wants_count { get; set; }
        public int offers_count { get; set; }
        public int archived_wants_count { get; set; }
        public bool pushNotificationsSoundAllowed { get; set; }
        public Kwork[] kworks { get; set; }
        public KworkReviews[] reviews { get; set; }
    }
}
