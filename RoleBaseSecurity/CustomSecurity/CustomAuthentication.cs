using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace RoleBaseSecurity.CustomSecurity
{
    public class CustomAuthentication : FilterAttribute, IAuthenticationFilter
    {
        //Execute before action method.
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Whether your user is authenticate or not
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();

            //Only few action result can return value; ViewResult, JSONResult, RedirectToRouteResult, HttpUnauthorizedResult

        }
        //Execute before the result generation of your action method.
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller="Account", Action="Login"}));
        }
    }
}