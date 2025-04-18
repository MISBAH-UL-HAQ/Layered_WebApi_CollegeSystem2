using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class RegisterUser : IdentityUser  // Inherit from IdentityUser
    {
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
    }
}
