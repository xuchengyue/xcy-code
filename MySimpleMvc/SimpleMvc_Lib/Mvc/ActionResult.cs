using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvc_Lib.Mvc
{
    public abstract class ActionResult
    {
        public abstract void Execute(RequestContext context);
    }
}
