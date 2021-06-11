using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkReviews
    {
        public long id { get; set; }
        public long time_added { get; set; }
        public string text { get; set; }
        public object auto_mode { get; set; }
        public bool good { get; set; }
        public bool bad { get; set; }

        public KworkReviewKwork kwork { get; set; }
        public KworkReviewWriter writer { get; set; }
        public KworkReviewAnswer answer { get; set; }


    }
}
