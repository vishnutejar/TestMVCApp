using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace TestMVCApp.Models
{
	public class AuthAttribute : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.Filters.IAuthenticationFilter
	{
		private bool _auth;
		public void OnAuthentication(AuthenticationContext authenticationContext)
		{
			_auth = (authenticationContext.ActionDescriptor.GetCustomAttributes
						(typeof(OverrideAuthenticationAttribute), true).Length == 0);
			//Logic for authenticating a user    
		}

		//Runs after the OnAuthentication method    
		public void OnAuthenticationChallenge(AuthenticationChallengeContext authenticationChallengeContext)
		{
			var user = authenticationChallengeContext.HttpContext.User;
			if(user==null || !user.Identity.IsAuthenticated)
			{
				authenticationChallengeContext.Result = new HttpUnauthorizedResult();
			}
			//TODO: Additional tasks on the request    
		}
	}
}