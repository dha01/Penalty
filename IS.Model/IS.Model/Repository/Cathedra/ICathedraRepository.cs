using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Cathedra;
using IS.Model.Repository;

namespace IS.Model.Repository.Cathedra
{
	/// <summary>
	/// Интерфейс репозитория кафедр.
	/// </summary>
	public interface ICathedraRepository : IRepository<CathedraItem>
	{
		/// <summary>
		/// Получает кафудру по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Кафедра.</returns>
		CathedraItem Get(int id);

		/// <summary>
		/// Обновляет данные по кафедре.
		/// </summary>
		/// <param name="сathedra">Кафедра.</param>
		void Update(CathedraItem сathedra);

		/// <summary>
		/// Создает новую кафедру.
		/// </summary>
		/// <param name="сathedra">Кафедра.</param>
		/// <returns>Идентификатор созданной кафедры.</returns>
		int Create(CathedraItem сathedra);

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех кафедр.
		/// </summary>
		/// <returns>Список кафедр.</returns>
		List<CathedraItem> GetList();
	}
}
