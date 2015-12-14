using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Access;
using IS.Model.Service;
using IS.Mvc.Models;
using IS.Model.Item.Team;
using IS.Model.Repository.Team;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с группами.
	/// </summary>
	public class TeamController : Controller
	{

		private TeamService _teamService;

		/// <summary>
		/// Конструктор контроллера групп.
		/// </summary>
		public TeamController()
		{
			_teamService = new TeamService();
		}

		/// <summary>
		/// Список групп.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			Access.CheckAccess("Team.Reader");
			return View("List", _teamService.GetList().OrderBy(x => x.Name).ToList());
		}

		/// <summary>
		/// Страница с группой. Если идентификатор не указан перенаправляет на список групп.
		/// </summary>
		/// <param name="id">Идентификатор группы.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			Access.CheckAccess("Team.Reader");
			if (id.HasValue)
			{
				return View("Index", _teamService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Создает новую группу.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(TeamItem team)
		{
			Access.CheckAccess("Team.Creator");
			return RedirectToAction("Index", new { id = _teamService.Create(team) });
		}

		/// <summary>
		/// Интерфейс для создания группы.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Team.Creator");
			return View();
		}

		/// <summary>
		/// Сохраняет измменения у группы.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(TeamItem team)
		{
			Access.CheckAccess("Team.Updater");
			_teamService.Update(team);
			return RedirectToAction("Index", new { id = team.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования группы.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Team.Updater");
			return View(_teamService.GetById(id));
		}

		/// <summary>
		/// Удаление группы.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Team.Deleter");
			_teamService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}