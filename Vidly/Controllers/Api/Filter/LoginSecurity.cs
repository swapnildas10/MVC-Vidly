using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Vidly.Controllers.Api.Filter
{
    public class LoginSecurity
    {
        private ApplicationSignInManager _signInManager;
        public  bool Login(string username, string password)
        {

            var result = SignInManager.PasswordSignInAsync(username, password, isPersistent: false, shouldLockout: false);
            if (result.Result == SignInStatus.Success)

                return true;
            return false;
          
        }

        public LoginSecurity()
        {
            
        }
        public  LoginSecurity( ApplicationSignInManager signInManager)
        {
          
            SignInManager = signInManager;
           
        }



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

    }
}