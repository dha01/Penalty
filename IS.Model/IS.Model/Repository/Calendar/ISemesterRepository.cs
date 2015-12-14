using System.Collections.Generic;
using IS.Model.Item.Calendar;

namespace IS.Model.Repository.Calendar
{
	/// <summary>
	/// Интерфейс репозитория семестра.
	/// </summary>
	public interface ISemesterRepository : IRepository<SemesterItem>
	{
		/// <summary>
		/// Получает семестр по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Семестр.</returns>
		SemesterItem Get(int id);

		/// <summary>
		/// Обновляет данные по семестру.
		/// </summary>
		/// <param name="semester">Семестр.</param>
		void Update(SemesterItem semester);

		/// <summary>
		/// Создает новый семестр.
		/// </summary>
		/// <param name="semester">Семестр.</param>
		/// <returns>Идентификатор созданного семестра.</returns>
		int Create(SemesterItem semester);

		/// <summary>
		/// Удаляет семестр.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех семестров.
		/// </summary>
		/// <returns>Список семестров.</returns>
		List<SemesterItem> GetList();
	}
}