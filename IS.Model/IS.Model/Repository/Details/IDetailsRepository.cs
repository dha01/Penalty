using System.Collections.Generic;
using IS.Model.Item.Details;

namespace IS.Model.Repository.Details
{
	/// <summary>
	/// Интерфейс репозитория деталей.
	/// </summary>
	public interface IDetailsRepository : IRepository<DetailsItem>
	{
		/// <summary>
		/// Получает деталь по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Деталь.</returns>
		DetailsItem Get(int id);

		/// <summary>
		/// Обновляет данные по автомобилю.
		/// </summary>
		/// <param name="details">Деталь.</param>
		void Update(DetailsItem details);

		/// <summary>
		/// Создает новую деталь.
		/// </summary>
		/// <param name="details">Деталь.</param>
		/// <returns>Идентификатор созданной детали.</returns>
		int Create(DetailsItem details);

		/// <summary>
		/// Удаляет деталь.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех деталей.
		/// </summary>
		/// <returns>Список деталей.</returns>
		List<DetailsItem> GetList();
	}
}