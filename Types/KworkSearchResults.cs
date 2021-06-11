using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwork.Types
{
    public class KworkSearchResults
    {
        public int kworks_count { get; set; }
        public Kwork[] kworks { get; set; }
    }
}
