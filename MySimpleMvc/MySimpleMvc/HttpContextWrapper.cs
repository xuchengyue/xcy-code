using System.Collections;
using System.Collections.Generic;
using System.Web;

namespace MySimpleMvc
{
    public class HttpContextWrapper
    {
        public HttpContext context { get; set; }
        public IDictionary<string, string> routeData { get; set; }
    }
}