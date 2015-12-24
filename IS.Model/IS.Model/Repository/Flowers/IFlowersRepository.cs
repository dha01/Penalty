using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Flowers;

namespace IS.Model.Repository.Flowers
{
	/// <summary>
	/// Интерфейс репозитория цветов.
	/// </summary>
	public interface IFlowersRepository : IRepository<FlowersItem>
	{
		/// <summary>
		/// Получает цветок по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Факультет.</returns>
		FlowersItem Get(int id);

		/// <summary>
		/// Обновляет данные по цветам.
		/// </summary>
		/// <param name="flowers">Цветок.</param>
		void Update(FlowersItem flowers);

		/// <summary>
		/// Создает новый цветок.
		/// </summary>
		/// <param name="flowers">Цветок.</param>
		/// <returns>Идентификатор созданного цветка.</returns>
		int Create(FlowersItem flowers);

		/// <summary>
		/// Удаляет цветок.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех цветов.
		/// </summary>
		/// <returns>Список цветов.</returns>
		List<FlowersItem> GetList();
	}
}
