using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkWorker
    {
        public long id { get; set;}
        public string username { get; set; }
        public string fullname { get; set; }
        public string profilepicture { get; set; }
        public decimal rating { get; set; }
        public int reviews_count { get; set; }
        public int rating_count { get; set; }
        public bool is_online { get; set; }
    }
}
