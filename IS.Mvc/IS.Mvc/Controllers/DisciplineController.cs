using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Discipline;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными по дисциплинам.
	/// </summary>
	public class DisciplineController : Controller
	{
		private DisciplineService _disciplineService;
	/// <summary>
	/// Создание сервиса дисциплин.
	/// </summary>
		public DisciplineController()
		{
			_disciplineService = new DisciplineService();
		}

		/// <summary>
		/// Страница с дисциплиной. Если идентификатор не указан перенаправляет на список дисциплин.
		/// </summary>
		/// <param name="id">Идентификатор дисциплины.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			Access.CheckAccess("Discipline.Reader");
			if (id.HasValue)
			{
				return View("Index", _disciplineService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Список дисциплин.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			Access.CheckAccess("Discipline.Reader");
			return View("List", _disciplineService.GetList().OrderBy(x => x.ShortName).ToList());
		}

		/// <summary>
		/// Создает новую дисциплину.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(DisciplineItem discipline)
		{
			Access.CheckAccess("Discipline.Creator");
			return RedirectToAction("List", new { id = _disciplineService.Create(discipline) });
		}

		/// <summary>
		/// Интерфейс для создания дисциплины.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Discipline.Creator");
			var defaultitem = new DisciplineItem();
			
			return View(defaultitem);
		}

		/// <summary>
		/// Сохраняет изменения в дисциплине.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(DisciplineItem discipline)
		{
			Access.CheckAccess("Discipline.Updater");
			_disciplineService.Update(discipline);
			return RedirectToAction("Index", new { id = discipline.Id });
			
		}


		/// <summary>
		/// Интерфейс для редактирования дисциплины.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			Access.CheckAccess("Discipline.Updater");
			return View( _disciplineService.GetById(id));

		}

		/// <summary>
		/// Интерфейс для редактирования дисциплины.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			 Access.CheckAccess("Discipline.Deleter");
			_disciplineService.Delete(id);
			return RedirectToAction("Index");
		}

	}
}
