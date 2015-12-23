using System;
using System.Transactions;
using IS.Model.Item.Product;
using IS.Model.Repository.Product;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Product
{
	/// <summary>
	/// Тесты для репозитория продуктов.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class ProductRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий продуктов.
		/// </summary>
		private ProductRepository _productRepository;

		private ProductItem _product;
		private ProductItem _productNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_productRepository = new ProductRepository();

			_product = new ProductItem()
			{
				ExpirationDate = DateTime.Now.Date,
				ProductType = ProductType.Bread,
				Name = "Test1",
				Position = 3,
				Price = 31,
				Unit = ProductUnit.Kilogram
			};
			_productNew = new ProductItem()
			{
				ExpirationDate = DateTime.Now.Date,
				ProductType = ProductType.Fish,
				Name = "Test2",
				Position = 1,
				Price = 54,
				Unit = ProductUnit.Liter
			};
		}

		#endregion

		#region TearDown

		/// <summary>
		/// Выполняется после каждого теста.
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			_transactionScope.Dispose();
		}

		#endregion

		#region Methods

		/// <summary>
		/// Проверяет еквивалентны ли два продукта.
		/// </summary>
		/// <param name="first_product">Первый продукт.</param>
		/// <param name="second_product">Второй продукт.</param>
		private void AreEqualProducts(ProductItem first_product, ProductItem second_product)
		{
			Assert.AreEqual(first_product.Id, second_product.Id);
			Assert.AreEqual(first_product.ExpirationDate, second_product.ExpirationDate);
			Assert.AreEqual(first_product.Name, second_product.Name);
			Assert.AreEqual(first_product.ProductType, second_product.ProductType);
			Assert.AreEqual(first_product.Position, second_product.Position);
			Assert.AreEqual(first_product.Price, second_product.Price);
			Assert.AreEqual(first_product.Unit, second_product.Unit);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает продукт.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_product.Id = _productRepository.Create(_product);
			var result = _productRepository.Get(_product.Id);
			AreEqualProducts(result, _product);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры продукта.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedProduct()
		{
			_product.Id = _productRepository.Create(_product);
			var result = _productRepository.Get(_product.Id);
			AreEqualProducts(result, _product);

			_productNew.Id = _product.Id;
			_productRepository.Update(_productNew);
			result = _productRepository.Get(_product.Id);
			AreEqualProducts(result, _productNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет продукт.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_product.Id = _productRepository.Create(_product);
			var result = _productRepository.Get(_product.Id);
			AreEqualProducts(result, _product);

			_productRepository.Delete(_product.Id);
			result = _productRepository.Get(_product.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех продуктов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithProduct()
		{
			_product.Id = _productRepository.Create(_product);
			var result = _productRepository.GetList().Find(x => x.Id == _product.Id);
			AreEqualProducts(result, _product);
		}

		#endregion
	}
}