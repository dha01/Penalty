using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using IS.Model.Item.Access;
using IS.Model.Repository.Access;

namespace IS.Mvc.Models.Service
{
	public class AccessService
	{
		private IUserRepository _userRepository;
		private IRoleRepository _roleRepository;

		public AccessService()
		{
			_userRepository = new UserRepository();
			_roleRepository = new RoleRepository();
		}

		public AccessService(IUserRepository user_repository, IRoleRepository role_repository)
		{
			_userRepository = user_repository;
			_roleRepository = role_repository;
		}

		private const string AUTH_COOKIE_NAME = "AuthCookie";

		/// <summary>
		/// Generate password
		/// </summary>
		/// <param name="pass">Original password</param>
		/// <param name="salt">User ID + " " + User.ID</param>
		/// <returns></returns>
		public string GeneratePassword(string pass, string salt)
		{
			string instr = pass + salt + " " + salt;
			string strHash = string.Empty;

			foreach (byte b in new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(instr)))
			{
				strHash += b.ToString("X2");
			}
			return strHash;
		}

		public void SetValue(string cookieName, string cookieObject, DateTime dateStoreTo)
		{

			HttpCookie cookie = HttpContext.Current.Response.Cookies[cookieName];
			if (cookie == null)
			{
				cookie = new HttpCookie(cookieName);
				cookie.Path = "/";
			}

			cookie.Value = cookieObject;
			cookie.Expires = dateStoreTo;

			HttpContext.Current.Response.SetCookie(cookie);
		}

		public void Login(UserItem user, bool remember)
		{
			DateTime expiresDate = DateTime.Now.AddHours(6);
			if (remember)
				expiresDate = expiresDate.AddDays(10);


			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
				1,
				user.Login,
				DateTime.Now,
				expiresDate, remember, user.Id.ToString());
			string encryptedTicket = FormsAuthentication.Encrypt(ticket);

			SetValue(AUTH_COOKIE_NAME, encryptedTicket, expiresDate);
		}

		public void Register(UserItem user)
		{
			new UserService().Create(user);
		}

		public bool Login(string login, string password, bool remember)
		{
			var user = _userRepository.GetUserByLogin(login);
			if (user == null)
			{
				return false;
			}
			if (string.CompareOrdinal(password, user.Password) == 0)
			{
				Login(user, remember);
				return true;
			}
			return false;
		}

		public void Logoff()
		{
			SetValue(AUTH_COOKIE_NAME, null, DateTime.Now.AddDays(-1));
		}

		public bool UserInRole(UserItem user, string role_code)
		{
			var role = _roleRepository.GetByCode(role_code);
			return UserInRole(user, role);
		}

		public bool UserInRole(UserItem user, RoleItem role)
		{
			var list = _roleRepository.GetListByUser(user);
			return list.Exists(x => x.Code == "Admin" || role.Code.StartsWith(x.Code));
		}

		public bool CheckRole(string role)
		{
			var user = GetCurrentUser();
			if (user == null)
			{
				return false;
			}

			if (string.IsNullOrEmpty(role))
			{
				return true;
			}

			if (!UserInRole(user, role))
			{
				return false;
			}
			
			return true;
		}

		public bool CheckRole(RoleItem role)
		{
			var user = GetCurrentUser();
			if (user == null)
			{
				return false;
			}

			if (role == null)
			{
				return true;
			}

			if (!UserInRole(user, role))
			{
				return false;
			}

			return true;
		}

		public bool CheckRoleByCode(string role_code)
		{
			var user = GetCurrentUser();
			if (user == null)
			{
				return false;
			}
			return UserInRole(user, role_code);
		}

		public UserItem GetCurrentUser()
		{
			try
			{
				object cookie = HttpContext.Current.Request.Cookies[AUTH_COOKIE_NAME] != null ? HttpContext.Current.Request.Cookies[AUTH_COOKIE_NAME].Value : null;
				if (cookie != null && !string.IsNullOrEmpty(cookie.ToString()))
				{
					var ticket = FormsAuthentication.Decrypt(cookie.ToString());
					return _userRepository.Get(int.Parse(ticket.UserData));
				}

			}
			catch (Exception ex)
			{
				return null;
			}
			return null;
		}

	}
}