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
        public static string GenerateSystemCode(string entity)
        {
            return string.Format("{0}_{1}", entity, DateTime.Now.Ticks.ToString());
        }
    }
}
