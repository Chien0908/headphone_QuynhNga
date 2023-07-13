using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace test.Identity
{
    public class AppUser:IdentityUser 
    {
        public DateTime? Birthday { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
    }
}