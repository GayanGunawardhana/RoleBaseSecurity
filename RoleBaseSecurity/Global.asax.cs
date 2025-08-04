using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using RoleBaseSecurity.CustomSecurity;

namespace RoleBaseSecurity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        //Create Post Authenticate Event
        protected void Application_PostAuthenticateRequest(Object sender,EventArgs e)
        {
            //Step04: Get Authentication Ticket from the Cookie
            HttpCookie authCookie = Request.Cookies.Get(FormsAuthentication.FormsCookieName);

            // Check whether cookie expired or not(Condition)
            if(authCookie!=null)
            {
                //Step05: Decrypt the Authentication Ticket
                FormsAuthenticationTicket ticket =FormsAuthentication.Decrypt(authCookie.Value);

                //Fetch the data from the ticket
                String Udata = ticket.UserData;

                //Convert it to aarray
                string[] userdata = Udata.Split('|');

                //Step06: Assign Ticket to principal object
                //Create custom principal class, fisrt of all need to create CustomerSecurity folder and then create CustomPrincipal class inside that folder.

                //Pass the data to this contructor
                CustomPrincipal myuser = new CustomPrincipal(userdata[0]);

                myuser.Name = userdata[1];
                myuser.Contact = userdata[2];
                myuser.Email = userdata[3];
                myuser.RoleName = userdata[4];

                //Step07: Persist Principal object to HTTPContext

                HttpContext.Current.User = myuser;



            }
             
        }
    }
}
