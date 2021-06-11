using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkWorkerOrderPayer
    {
        public int id { get; set; }
        public string username { get; set; }
        public bool is_online { get; set; }
        public string profilepicture { get; set; }
    }
}
