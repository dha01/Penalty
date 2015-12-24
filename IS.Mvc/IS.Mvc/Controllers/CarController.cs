using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Car;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными автомобилей.
	/// </summary>
	public class CarController : Controller
	{
		private CarService _carService;
		
		public CarController()
		{
			_carService = new CarService();
		}
		
		/// <summary>
		/// Страница с информацией автомобиля. Если идентификатор не указан перенаправляет на список автомобилей.
		/// </summary>
		/// <param name="id">Идентификатор автомобиля.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			if (id.HasValue)
			{
				return View("Index", _carService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Список автомобилей.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			return View("List", _carService.GetList());
		}

		/// <summary>
		/// Создает новый автомобиль.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(CarItem car)
		{
			Access.CheckAccess("Car.Creator");
			return RedirectToAction("Index", new { id = _carService.Create(car) });
		}

		/// <summary>
		/// Интерфейс для создания автомобиля.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Car.Creator");
			var default_item = new CarItem
			{
				Brand = CarBrand.Audi,
				Color = CarColor.Black
			};
			return View(default_item);
		}

		/// <summary>
		/// Сохраняет измменения автомобиля.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(CarItem car)
		{
			Access.CheckAccess("Car.Updater");
			_carService.Update(car);
			return RedirectToAction("Index", new { id = car.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования автомобиля.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			return View(_carService.GetById(id));
		}

		/// <summary>
		/// Интерфейс для удаления автомобиля.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Car.Deleter");
			_carService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
