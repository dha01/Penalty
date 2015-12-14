using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Housing;

namespace IS.Model.Repository.Housing
{
	/// <summary>
	/// Интерфейс репозитория корпусов.
	/// </summary>
	public interface IHousingRepository : IRepository<HousingItem>
	{
		/// <summary>
		/// Получает корпус по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Корпус.</returns>
		HousingItem Get(int id);

		/// <summary>
		/// Обновляет данные по корпусу.
		/// </summary>
		/// <param name="housing">Корпус.</param>
		void Update(HousingItem housing);

		/// <summary>
		/// Создает новый корпус.
		/// </summary>
		/// <param name="housing">Корпус.</param>
		/// <returns>Идентификатор созданного корпуса.</returns>
		int Create(HousingItem housing);

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех корпусов.
		/// </summary>
		/// <returns>Список корпусов.</returns>
		List<HousingItem> GetList();
	}
}
