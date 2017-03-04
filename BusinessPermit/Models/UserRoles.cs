using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessPermit.Models
{
    public class UserRoles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}