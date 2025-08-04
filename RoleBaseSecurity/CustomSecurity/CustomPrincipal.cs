using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace RoleBaseSecurity.CustomSecurity
{
    public class CustomPrincipal : IPrincipal
    {
        

        public CustomPrincipal(string username)
        {
            // Assigning username parameter to Identity property
            Identity =new GenericIdentity(username);

        }

        //This is an Identity PROPERTY, ONLY READ by the user.
        public IIdentity Identity
        {
            get;
            private set;
        }


        public bool IsInRole(string role)
        {
            //This will be useful for authorization. This role argument will have the requred role.
            //If the two values are same means required role snd role both sre dsmr thst means user, user is authorized then you will return TRUE.
            if (role == RoleName)
                return true;
            else
                return false;
        }

        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        //This role name property will have the user role value.

    }
}