using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkReviewAnswer
    {
        public long id { get; set; }
        public string text { get; set; }
        public long user_id { get; set; }
        public long time_added { get; set; }
        public string username { get; set; }
        public string profilepicture { get; set; }
    }
}
