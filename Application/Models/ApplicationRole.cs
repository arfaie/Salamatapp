using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Application.Models
{
    public class ApplicationRole: IdentityRole
    {
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> user { get; set; }
    }
}
