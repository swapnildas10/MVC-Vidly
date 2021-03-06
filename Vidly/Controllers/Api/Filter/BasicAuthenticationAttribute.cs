﻿using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Vidly.Controllers.Api.Filter
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
               string[] userNamePassword = decodedAuthenticationToken.Split(':');
                string userName = userNamePassword[0];
                string password = userNamePassword[1];

                if (new LoginSecurity().Login(userName, password))
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                else
                    
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}