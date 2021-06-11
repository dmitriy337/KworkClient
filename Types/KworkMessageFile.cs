using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkMessageFile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string miniature_url { get; set; }
        public string miniature_path { get; set; }
        public int size { get; set; }
        public string imageData { get; set; }
        public int timestamp { get; set; }
        public string status { get; set; }
    }
}
