using SPEEDYDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSCommons
{
    public class SSHelper
    {
        public static string GenerateSystemCode()
        {
            return DateTime.Now.Ticks.ToString();
        }
        
    }
}
