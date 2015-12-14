using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Access;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с ролями у пользователей.
	/// </summary>
	public class RoleController : Controller
	{

		private RoleService _roleService;

		/// <summary>
		/// Конструктор контроллера ролей.
		/// </summary>
		public RoleController()
		{
			_roleService = new RoleService();
		}

		/// <summary>
		/// Список ролей.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			Access.CheckAccess("Role.Reader");
			return View("List", _roleService.GetList().OrderBy(x => x.Code).ToList());
		}

		/// <summary>
		/// Страница с ролью. Если идентификатор не указан перенаправляет на список ролей.
		/// </summary>
		/// <param name="id">Идентификатор роли.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			Access.CheckAccess("Role.Reader");
			if (id.HasValue)
			{
				return View("Index", _roleService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Создает новую роль.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(RoleItem role)
		{
			Access.CheckAccess("Role.Creator");
			return RedirectToAction("Index", new { id = _roleService.Create(role) });
		}

		/// <summary>
		/// Интерфейс для создания роли.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Role.Creator");
			return View();
		}

		/// <summary>
		/// Сохраняет измменения у роли.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(RoleItem role)
		{
			Access.CheckAccess("Role.Updater");
			_roleService.Update(role);
			return RedirectToAction("Index", new { id = role.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования роли.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Role.Updater");
			return View(_roleService.GetById(id));
		}

		/// <summary>
		/// Удаление роли.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Role.Deleter");
			_roleService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}