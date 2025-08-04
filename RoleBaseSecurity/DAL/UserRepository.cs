using RoleBaseSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoleBaseSecurity.DataModels;

namespace RoleBaseSecurity.DAL
{
    public class UserRepository
    {
        //Validate the user against the LoginViewModel- We will accept this LoginViewModel and we will return UserViewModel which contain user details.
        public UserViewModel Validate(LoginViewModel model)
        {
            MyCRUD_DbEntities db = new MyCRUD_DbEntities();
            User Obj=db.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();

            if(Obj!=null)
            {
                UserViewModel userModel = new UserViewModel();
                userModel.Username = Obj.Username;
                userModel.Name = Obj.Name;
                userModel.Contact = Obj.Contact;
                userModel.Email = Obj.Email;
                userModel.RoleName = Obj.RoleName;
                return userModel;

            }
            else
            {
                return null; 
            }
        }
    }
}