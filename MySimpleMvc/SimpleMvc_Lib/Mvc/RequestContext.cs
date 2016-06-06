using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SimpleMvc_Lib.Mvc
{
    public class RequestContext
    {
        public HttpContext rContext { get; set; }

        public IDictionary<string, string> routeData { get; set; }
    }
}
