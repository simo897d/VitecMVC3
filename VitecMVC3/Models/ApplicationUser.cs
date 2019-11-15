using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VitecMVC3.Models
{
    public class ApplicationUser : IdentityUser {
        public bool HasProduct {get;set;}
    }
}
