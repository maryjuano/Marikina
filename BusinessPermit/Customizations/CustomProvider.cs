using BusinessPermit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BusinessPermit
{
    public class PortalProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            string userRole = string.Empty;
            ApplicationDbContext db = new ApplicationDbContext();

            var user = db.Users.SingleOrDefault(u => u.UserName == username);
           
            if (user != null && user.UserRoleId > 0)
            {
                var roles = db.UserRoles.SingleOrDefault(r => r.RoleId == user.UserRoleId);
                if (roles != null)
                {
                    userRole = roles.RoleName;
                }               
            }

            return new string[] { userRole };
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}