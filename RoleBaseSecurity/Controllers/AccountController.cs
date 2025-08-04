using RoleBaseSecurity.DAL;
using RoleBaseSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RoleBaseSecurity.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserRepository repoUser = new UserRepository();
                UserViewModel userModel = repoUser.Validate(model);
                if (userModel!=null)
                {
                    // Create string UserData parameter values
                       // Place holder ==> "{0}|{1}|{2}|{3}"
                    string userData = string.Format("{0}|{1}|{2}|{3}|{4}",userModel.Username, userModel.Name, userModel.Contact, userModel.Email, userModel.RoleName);

                    //Step 01: Create Form Authentication ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,userModel.Username,DateTime.Now,DateTime.Now.AddMinutes(10), false,userData);

                    //Step 02: Encrypt the Authentication Ticket
                    String CookieValue =FormsAuthentication.Encrypt(ticket);

                    //Step 03: Add Authentication Ticket to Cookie
                       //Instead of this "FormsAuthentication.FormsCookieName" ("ASPXAUTH" is the default name.) , you can user any name.
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, CookieValue);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index","Home");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Data");
                return View();

            }


            return View();

        }

        public ActionResult Unauthorize()
        {
            return View();

        }
        public RedirectToRouteResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}