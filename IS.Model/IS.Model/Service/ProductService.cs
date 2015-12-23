using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Product;
using IS.Model.Repository.Product;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с продуктами.
	/// </summary>
	public class ProductService
	{
		#region Fields

		/// <summary>
		/// Репозиторий продуктов.
		/// </summary>
		private IProductRepository _productRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public ProductService()
		{
			_productRepository = new ProductRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="product_repository">Интерфейс репозитория продуктов.</param>
		public ProductService(IProductRepository product_repository)
		{
			_productRepository = product_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает продукт по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Продукт.</returns>
		public ProductItem GetById(int id)
		{
			return _productRepository.Get(id);
		}

		/// <summary>
		/// Создает продукт.
		/// </summary>
		/// <param name="product">Продукт.</param>
		/// <returns>Идентификатор созданного продукта.</returns>
		public int Create(ProductItem product)
		{
			if (string.IsNullOrEmpty(product.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			return _productRepository.Create(product);
		}

		/// <summary>
		/// Измененяет данные продукта.
		/// </summary>
		/// <param name="product">Продукт.</param>
		public void Update(ProductItem product)
		{
			if (string.IsNullOrEmpty(product.Name))
			{
				throw new Exception("Поле 'Name' не должно быть пустым.");
			}

			if (GetById(product.Id) == null)
			{
				throw new Exception("Продукт не найден.");
			}

			_productRepository.Update(product);
		}

		/// <summary>
		/// Удаляет продукт.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_productRepository.Delete(id);
		}

		/// <summary>
		/// Получает список продуктов.
		/// </summary>
		public List<ProductItem> GetList()
		{
			return _productRepository.GetList();
		}

		#endregion
	}
}