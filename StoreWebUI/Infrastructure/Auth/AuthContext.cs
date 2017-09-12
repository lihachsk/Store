using Microsoft.AspNet.Identity.EntityFramework;
using StoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWebUI.Infrastructure.Auth
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext() : base("Store") { }
        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }
}