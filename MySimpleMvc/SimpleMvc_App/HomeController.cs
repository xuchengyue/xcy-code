using SimpleMvc_Lib.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleMvc_App
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return new ContentResult("testContent", "text/html");
        }
    }
}