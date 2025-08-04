using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBaseSecurity.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}