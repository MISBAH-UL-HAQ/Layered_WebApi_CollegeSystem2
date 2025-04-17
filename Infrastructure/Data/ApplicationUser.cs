using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public int DepartmentId { get; set; }  // Foreign key
        public Department Department { get; set; }  // Navigation property
    }
}