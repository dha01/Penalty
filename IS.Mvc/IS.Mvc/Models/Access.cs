using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using IS.Model.Item.Access;
using IS.Mvc.Models.Service;

namespace IS.Mvc.Models
{
	public class Access
	{
		private static AccessService _accessService;

		static Access()
		{
			_accessService = new AccessService();
		}

		public bool UserInRole(UserItem user, string role_code)
		{
			return _accessService.UserInRole(user, role_code);
		}
		
		public static bool UserInRole(UserItem user, RoleItem role)
		{
			return _accessService.UserInRole(user, role);
		}

		public static void CheckAccess(string role = null)
		{
			if (!CheckRole(role))
			{
				throw new Exception("Недостаточно прав.");
			}
		}

		public static bool CheckRole(string role = null)
		{
			return _accessService.CheckRole(role);
		}

		public static void CheckRole(RoleItem role)
		{
			_accessService.CheckRole(role);
		}

		public static UserItem CurrentUser 
		{
			get { return _accessService.GetCurrentUser(); }
		}
	}
}