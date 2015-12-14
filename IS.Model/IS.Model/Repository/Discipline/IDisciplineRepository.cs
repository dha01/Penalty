using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Discipline;

namespace IS.Model.Repository.Discipline
{
	/// <summary>
	/// Интерфейс репозитория дисциплин.
	/// </summary>
	public interface IDisciplineRepository : IRepository<DisciplineItem>
	{
		/// <summary>
		/// Получает дисциплину по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Дисциплина.</returns>
		DisciplineItem Get(int id);

		/// <summary>
		/// Обновляет данные по дисциплине.
		/// </summary>
		/// <param name="discipline">Дисциплина.</param>
		void Update(DisciplineItem discipline);

		/// <summary>
		/// Создает новую дисциплину.
		/// </summary>
		/// <param name="discipline">Дисциплина.</param>
		/// <returns>Идентификатор созданной дисциплины.</returns>
		int Create(DisciplineItem discipline);

		/// <summary>
		/// Удаляет дисциплину.
		/// </summary>
		/// <param name="id">Дисциплина.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех дисциплин.
		/// </summary>
		/// <returns>Список дисциплин.</returns>
		List<DisciplineItem> GetList();
	}
}