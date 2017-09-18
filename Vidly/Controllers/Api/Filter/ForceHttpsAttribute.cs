﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Vidly.Controllers.Api.Filter
{
    public class ForceHttpsAttribute : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                Console.Write("Hehe");
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Found);
                actionContext.Response.Content = new StringContent("<p>Use HTTPS instead of HTTP</p>",Encoding.UTF8,"text/html");
                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
                uriBuilder.Scheme = Uri.UriSchemeHttps;
                uriBuilder.Port = 44348;
                actionContext.Response.Headers.Location = uriBuilder.Uri;
            }
            else
            {
                Console.Write("Hehe 2");
                base.OnAuthorization(actionContext);

            }

        }
    }
}