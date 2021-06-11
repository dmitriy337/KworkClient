using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkProject
    {
        public long id { get; set; }
        public long user_id { get; set; }
        public string username { get; set; }
        public string profile_picture { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int offers { get; set; }
        public int time_left { get; set; }
        public int parent_category_id { get; set; }
        public int category_id { get; set; }
        public long date_confirm { get; set; }
        public int category_base_price { get; set; }
        public int user_projects_count { get; set; }
        public int user_hired_percent { get; set; }
        
        public KworkProjectAchieve[] achievements_list { get; set; }
        
        public bool is_viewed { get; set; }
        public int already_work { get; set; }
        public bool allow_higher_price { get; set; }
        public int possible_price_limit { get; set; }
    }
}
