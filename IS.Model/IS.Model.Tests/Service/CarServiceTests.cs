using System;
using System.Collections.Generic;
using IS.Model.Item.Car;
using IS.Model.Repository.Car;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса автомобилей.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class CarServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис автомобилей.
		/// </summary>
		private CarService _carService;

		/// <summary>
		/// Репозиторий автомобилей.
		/// </summary>
		private ICarRepository _carRepository;

		/// <summary>
		/// Тестовый автомобиль.
		/// </summary>
		private CarItem _car;
		private DateTime ReleaseDate;
		private CarBrand Brand;
		private CarColor Color;
		private string Mem;
		private int Vin;
		private int Price;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_carRepository = Mock.Of<ICarRepository>();
			_carService = new CarService(_carRepository);

			_car = new CarItem()
			{
				ReleaseDate = DateTime.Now.Date,
				Brand = CarBrand.Audi,
				Mem = "Test1",
				Vin = 131434123,
				Price = 121434431,
				Color = CarColor.Black
			};
		}

		#endregion

		#region CarService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void CarService_Void_Success()
		{
			var s = new CarService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает автомобиль.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<CarItem>() { _car };

			Mock.Get(_carRepository).Setup(x => x.Create(_car)).Returns(_car.Id);
			Mock.Get(_carRepository).Setup(x => x.GetList()).Returns(list);

			var result = _carService.Create(_car);
			Assert.AreEqual(result, _car.Id);
		}

		/// <summary>
		/// Создает автомобиль с пустым полем "Mem".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Create_EmptyMem_ReturnException()
		{
			_car.Mem = null;
			_carService.Create(_car);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные автомобиля.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_carRepository).Setup(x => x.Get(_car.Id)).Returns(_car);
			_carService.Update(_car);
		}

		/// <summary>
		/// Изменяет поле "Mem" на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Update_EmptyMem_ReturnException()
		{
			_car.Mem = null;
			_carService.Update(_car);
		}

		/// <summary>
		/// Изменяет не существующий автомобиль.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Автомобиль не найден.")]
		[Test]
		public void Update_CarNotExists_ReturnException()
		{
			Mock.Get(_carRepository).Setup(x => x.Get(_car.Id)).Returns((CarItem)null);
			_carService.Update(_car);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет автомобиль.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_carService.Delete(_car.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список автомобилей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnCarList()
		{
			var list = new List<CarItem> { _car };

			Mock.Get(_carRepository).Setup(x => x.GetList()).Returns(list);
			var result = _carService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion

	}
}
