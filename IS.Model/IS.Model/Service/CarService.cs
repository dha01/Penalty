using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Car;
using IS.Model.Repository.Car;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с автомобилями.
	/// </summary>
	public class CarService
	{
		#region Fields

		/// <summary>
		/// Репозиторий автомобилей.
		/// </summary>
		private ICarRepository _carRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public CarService()
		{
			_carRepository = new CarRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="car_repository">Интерфейс репозитория автомобилей.</param>
		public CarService(ICarRepository car_repository)
		{
			_carRepository = car_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает автомобиль по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Автомобиль.</returns>
		public CarItem GetById(int id)
		{
			return _carRepository.Get(id);
		}

		/// <summary>
		/// Создает автомобиль.
		/// </summary>
		/// <param name="car">Автомобиль.</param>
		/// <returns>Идентификатор созданного автомобиля.</returns>
		public int Create(CarItem car)
		{
			if (string.IsNullOrEmpty(car.Mem))
			{
				throw new Exception("Поле 'Mem' не должно быть пустым.");
			}

			return _carRepository.Create(car);
		}

		/// <summary>
		/// Измененяет данные автомобиля.
		/// </summary>
		/// <param name="car">Автомобиль.</param>
		public void Update(CarItem car)
		{
			if (string.IsNullOrEmpty(car.Mem))
			{
				throw new Exception("Поле 'Mem' не должно быть пустым.");
			}

			if (GetById(car.Id) == null)
			{
				throw new Exception("Автомобиль не найден.");
			}

			_carRepository.Update(car);
		}

		/// <summary>
		/// Удаляет автомобиль.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_carRepository.Delete(id);
		}

		/// <summary>
		/// Получает список задач.
		/// </summary>
		public List<CarItem> GetList()
		{
			return _carRepository.GetList();
		}

		#endregion
	}
}
