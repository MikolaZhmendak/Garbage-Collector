using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarbageCollector.Controllers
{
    public class userscontroller : Controller
    {
        [Authorize]
        // GET: userscontroller
        public ActionResult Index()
        {
            return View();
        }
    }
}