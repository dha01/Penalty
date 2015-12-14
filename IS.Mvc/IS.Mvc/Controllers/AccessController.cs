using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Access;
using IS.Mvc.Models;
using IS.Mvc.Models.Service;

namespace IS.Controllers
{
	public class AccessController : Controller
	{
		private AccessService _accessService;

		public AccessController()
		{
			_accessService = new AccessService();
		}

		public ActionResult Index()
		{
			var user = Access.CurrentUser;
			if (user == null)
			{
				return View();
			}

			return View(user);
		}

		/// <summary>
		/// Добавление роли.
		/// </summary>
		/// <returns></returns>
		public ActionResult AddRole()
		{
			return View("Error");
		}

		/// <summary>
		/// Авторизация.
		/// </summary>
		/// <param name="login">Логин.</param>
		/// <param name="password">Пароль.</param>
		/// <param name="remember">Запомнить.</param>
		/// <returns></returns>
		public ActionResult LoginByLoginAndPassword(string login, string password, bool remember)
		{
			if (_accessService.Login(login, password, remember))
			{
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.Message = "Ошибка авторизации. Проверте правильность введенного логина и пароля.";
				return View("Login");
			}
		}

		public ActionResult Login()
		{
			return View("Login");
		}

		public ActionResult Logoff()
		{
			_accessService.Logoff();
			return View("Index");
		}

		public ActionResult Registr()
		{
			return View("Registr");
		}

		/// <summary>
		/// Регистрация.
		/// </summary>
		/// <param name="login">Логин.</param>
		/// <param name="password">Пароль.</param>
		/// <returns></returns>
		public ActionResult RegistrByLoginAndPasword(string login, string password)
		{
			new UserService().Create(new UserItem()
			{
				Login = login,
				Password = password
			});
			return View("Index");
		}
	}
}
