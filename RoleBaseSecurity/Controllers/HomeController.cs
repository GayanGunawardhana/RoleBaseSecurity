using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoleBaseSecurity.CustomSecurity;

namespace RoleBaseSecurity.Controllers
{
    [CustomAuthentication]
    public class HomeController : Controller
    {
        // GET: Home
        [CustomAuthentication]
        [CustomAuthorization(Role ="Administrator")]
        public ActionResult Index()
        {
            return View();
        }
    }
}