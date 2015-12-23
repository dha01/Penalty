using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Details;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными деталей.
	/// </summary>
	public class DetailsController : Controller
	{
		private DetailsService _detailsService;

		public DetailsController()
		{
			_detailsService = new DetailsService();
		}

		/// <summary>
		/// Страница с информацией детали. Если идентификатор не указан перенаправляет на список деталей.
		/// </summary>
		/// <param name="id">Идентификатор детали.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			if (id.HasValue)
			{
				return View("Index", _detailsService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Список деталей.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			return View("List", _detailsService.GetList());
		}

		/// <summary>
		/// Создает новую деталь.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(DetailsItem details)
		{
			Access.CheckAccess("Details.Creator");
			return RedirectToAction("Index", new { id = _detailsService.Create(details) });
		}

		/// <summary>
		/// Интерфейс для создания детали.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Details.Creator");
			var default_item = new DetailsItem
			{
				Material = DetailsMaterial.Wood
			};
			return View(default_item);
		}

		/// <summary>
		/// Сохраняет измменения детали.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(DetailsItem details)
		{
			Access.CheckAccess("Details.Updater");
			_detailsService.Update(details);
			return RedirectToAction("Index", new { id = details.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования детали.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			return View(_detailsService.GetById(id));
		}

		/// <summary>
		/// Интерфейс для удаления детали.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Details.Deleter");
			_detailsService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}