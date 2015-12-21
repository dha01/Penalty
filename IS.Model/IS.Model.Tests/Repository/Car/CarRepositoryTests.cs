using System;
using System.Transactions;
using IS.Model.Item.Car;
using IS.Model.Repository.Car;
using NUnit.Framework;

namespace IS.Model.Tests.Repository.Car
{
	/// <summary>
	/// Тесты для репозитория автомобилей.
	/// </summary>
	[Category("Integration")]
	[TestFixture]
	public class CarRepositoryTests
	{
		#region Fields

		/// <summary>
		/// Транзакция.
		/// </summary>
		private TransactionScope _transactionScope;

		/// <summary>
		/// Репозиторий автомобилей.
		/// </summary>
		private CarRepository _carRepository;

		private CarItem _car;
		private CarItem _carNew;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_transactionScope = new TransactionScope();
			_carRepository = new CarRepository();

			_car = new CarItem()
			{
				ReleaseDate = DateTime.Now.Date,
				Brand = CarBrand.Audi,
				Mem = "Test1",
				Vin = 131434123,
				Price = 121434431,
				Color = CarColor.Black
			};
			_carNew = new CarItem()
			{
				ReleaseDate = DateTime.Now.Date,
				Brand = CarBrand.Chevrolet,
				Mem = "Test2",
				Vin = 1423423,
				Price = 154353454,
				Color = CarColor.Red
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
		/// Проверяет еквивалентны ли два автомобиля.
		/// </summary>
		/// <param name="first_car">Первый автомобиль.</param>
		/// <param name="second_car">Второй автомобиль.</param>
		private void AreEqualCars(CarItem first_car, CarItem second_car)
		{
			Assert.AreEqual(first_car.Id, second_car.Id);
			Assert.AreEqual(first_car.ReleaseDate, second_car.ReleaseDate);
			Assert.AreEqual(first_car.Brand, second_car.Brand);
			Assert.AreEqual(first_car.Mem, second_car.Mem);
			Assert.AreEqual(first_car.Price, second_car.Price);
			Assert.AreEqual(first_car.Vin, second_car.Vin);
			Assert.AreEqual(first_car.Color, second_car.Color);
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает автомобиль.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			_car.Id = _carRepository.Create(_car);
			var result = _carRepository.Get(_car.Id);
			AreEqualCars(result, _car);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет параметры автомобиля.
		/// </summary>
		[Test]
		public void Update_Void_ReturnChangedCar()
		{
			_car.Id = _carRepository.Create(_car);
			var result = _carRepository.Get(_car.Id);
			AreEqualCars(result, _car);

			_carNew.Id = _car.Id;
			_carRepository.Update(_carNew);
			result = _carRepository.Get(_car.Id);
			AreEqualCars(result, _carNew);

		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет автомобиль.
		/// </summary>
		[Test]
		public void Delete_Void_ReturnNull()
		{
			_car.Id = _carRepository.Create(_car);
			var result = _carRepository.Get(_car.Id);
			AreEqualCars(result, _car);

			_carRepository.Delete(_car.Id);
			result = _carRepository.Get(_car.Id);
			Assert.IsNull(result);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список всех автомобилей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnNotEmptyListWithCar()
		{
			_car.Id = _carRepository.Create(_car);
			var result = _carRepository.GetList().Find(x => x.Id == _car.Id);
			AreEqualCars(result, _car);
		}

		#endregion
	}
}
