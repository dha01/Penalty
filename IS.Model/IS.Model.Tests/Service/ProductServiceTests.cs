using System;
using System.Collections.Generic;
using IS.Model.Item.Product;
using IS.Model.Repository.Product;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса продуктов.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class ProductServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис продуктов.
		/// </summary>
		private ProductService _productService;

		/// <summary>
		/// Репозиторий продуктов.
		/// </summary>
		private IProductRepository _productRepository;

		/// <summary>
		/// Тестовый продукт.
		/// </summary>
		private ProductItem _product;
		private DateTime ExpirationDate;
		private ProductType ProductType;
		private ProductUnit Unit;
		private string Name;
		private int Position;
		private int Price;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_productRepository = Mock.Of<IProductRepository>();
			_productService = new ProductService(_productRepository);

			_product = new ProductItem()
			{
				ExpirationDate = DateTime.Now.Date,
				ProductType = ProductType.Bread,
				Name = "Test1",
				Position = 3,
				Price = 12,
				ProductUnit = ProductUnit.Liter
			};
		}

		#endregion

		#region ProductService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void ProductService_Void_Success()
		{
			var s = new ProductService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает продукт.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<ProductItem>() { _product };

			Mock.Get(_productRepository).Setup(x => x.Create(_product)).Returns(_product.Id);
			Mock.Get(_productRepository).Setup(x => x.GetList()).Returns(list);

			var result = _productService.Create(_product);
			Assert.AreEqual(result, _product.Id);
		}

		/// <summary>
		/// Создает продукт с пустым полем "Name".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Create_EmptyName_ReturnException()
		{
			_product.Name = null;
			_productService.Create(_product);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные продукта.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_productRepository).Setup(x => x.Get(_product.Id)).Returns(_product);
			_productService.Update(_product);
		}

		/// <summary>
		/// Изменяет поле "Name" на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Update_EmptyName_ReturnException()
		{
			_product.Name = null;
			_productService.Update(_product);
		}

		/// <summary>
		/// Изменяет не существующий продукт.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Продукт не найден.")]
		[Test]
		public void Update_ProductNotExists_ReturnException()
		{
			Mock.Get(_productRepository).Setup(x => x.Get(_product.Id)).Returns((ProductItem)null);
			_productService.Update(_product);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет продукт.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_productService.Delete(_product.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список продуктов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnProductList()
		{
			var list = new List<ProductItem> { _product };

			Mock.Get(_productRepository).Setup(x => x.GetList()).Returns(list);
			var result = _productService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion

	}
}