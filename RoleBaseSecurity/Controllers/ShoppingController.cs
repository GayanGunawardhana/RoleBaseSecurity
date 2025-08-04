using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoleBaseSecurity.CustomSecurity;

namespace RoleBaseSecurity.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        [CustomAuthentication]
        [CustomAuthorization(Role ="User")]
        public ActionResult Index()
        {
            return View();
        }
    }
}