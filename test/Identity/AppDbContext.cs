using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace test.Identity
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("MyCS") { }
    }
}