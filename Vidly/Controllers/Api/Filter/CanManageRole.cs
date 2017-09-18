using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Vidly.Models;

namespace Vidly.Controllers.Api.Filter
{
    public class CanManageRole : AuthorizationFilterAttribute
    {
        private string roleName;

        public CanManageRole()
        {
            
        }
        public CanManageRole(string roleName)
        {
            this.roleName = roleName;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
           

            var user = userManager.FindByName(Thread.CurrentPrincipal.Identity.Name);
            //check for user roles
            var rolesForUser = userManager.GetRoles(user.Id);
            //if user is not in role, add him to it
            if (!rolesForUser.Contains(RoleName.CanManageMovies))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                actionContext.Response.Content = new StringContent("<p>Use HTTPS instead of HTTP</p>", Encoding.UTF8, "text/html");
            }
               
            else
           // var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
          // var roles= roleManager.Roles;
           // roles.GetEnumerator();
           // if (!Roles.IsUserInRole(Thread.CurrentPrincipal.Identity.Name, roleName))
              //  actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}