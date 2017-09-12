using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using StoreDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreWebUI.Infrastructure.Auth
{
    public class UserManager2 : UserManager<User>
    {
        public UserManager2(IUserStore<User> store) : base(store) { }
        public static UserManager2 Create(IdentityFactoryOptions<UserManager2> options, IOwinContext context)
        {
            AuthContext db = context.Get<AuthContext>();
            UserManager2 manager = new UserManager2(new UserStore<User>(db));
            return manager;
        }
    }
}