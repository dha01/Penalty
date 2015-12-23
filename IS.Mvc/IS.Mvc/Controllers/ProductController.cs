using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Model.Item.Product;
using IS.Model.Service;
using IS.Mvc.Models;

namespace IS.Mvc.Controllers
{
	/// <summary>
	/// Контролер для работы с данными продуктов.
	/// </summary>
	public class ProductController : Controller
	{
		private ProductService _productService;

		public ProductController()
		{
			_productService = new ProductService();
		}
		
		/// <summary>
		/// Страница с информацией продукта. Если идентификатор не указан перенаправляет на список продуктов.
		/// </summary>
		/// <param name="id">Идентификатор продукта.</param>
		/// <returns></returns>
		public ActionResult Index(int? id)
		{
			if (id.HasValue)
			{
				return View("Index", _productService.GetById(id.Value));
			}
			else
			{
				return RedirectToAction("List");
			}
		}

		/// <summary>
		/// Список продуктов.
		/// </summary>
		/// <returns></returns>
		public ActionResult List()
		{
			return View("List", _productService.GetList());
		}

		/// <summary>
		/// Создает новый продукт.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Create(ProductItem product)
		{
			Access.CheckAccess("Product.Creator");
			return RedirectToAction("Index", new { id = _productService.Create(product) });
		}

		/// <summary>
		/// Интерфейс для создания продукта.
		/// </summary>
		/// <returns></returns>
		public ActionResult New()
		{
			Access.CheckAccess("Product.Creator");
			var default_item = new ProductItem
			{
				ProductType = ProductType.Bread,
				Unit = ProductUnit.Kilogram
			};
			return View(default_item);
		}

		/// <summary>
		/// Сохраняет измменения продукта.
		/// </summary>
		/// <returns></returns>
		[ValidateInput(false)]
		public ActionResult Update(ProductItem product)
		{
			Access.CheckAccess("Product.Updater");
			_productService.Update(product);
			return RedirectToAction("Index", new { id = product.Id });
		}

		/// <summary>
		/// Интерфейс для редактирования продукта.
		/// </summary>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			return View(_productService.GetById(id));
		}

		/// <summary>
		/// Интерфейс для удаления продукта.
		/// </summary>
		/// <returns></returns>
		public ActionResult Delete(int id)
		{
			Access.CheckAccess("Product.Deleter");
			_productService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}