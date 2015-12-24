using System.Collections.Generic;
using IS.Model.Item.Car;

namespace IS.Model.Repository.Car
{
	/// <summary>
	/// Интерфейс репозитория автомобилей.
	/// </summary>
	public interface ICarRepository : IRepository<CarItem>
	{
		/// <summary>
		/// Получает автомобиль по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Автомобиль.</returns>
		CarItem Get(int id);

		/// <summary>
		/// Обновляет данные по автомобилю.
		/// </summary>
		/// <param name="car">Автомобиль.</param>
		void Update(CarItem car);

		/// <summary>
		/// Создает новый автомобиль.
		/// </summary>
		/// <param name="car">Автомобиль.</param>
		/// <returns>Идентификатор созданного автомобиля.</returns>
		int Create(CarItem car);

		/// <summary>
		/// Удаляет автомобиль.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех автомобилей.
		/// </summary>
		/// <returns>Список автомобилей.</returns>
		List<CarItem> GetList();
	}
}