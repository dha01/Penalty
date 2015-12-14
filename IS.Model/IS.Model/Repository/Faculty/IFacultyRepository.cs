using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Faculty;

namespace IS.Model.Repository.Faculty
{
	/// <summary>
	/// Интерфейс репозитория факультетов.
	/// </summary>
	public interface IFacultyRepository : IRepository<FacultyItem>
	{
		/// <summary>
		/// Получает факультет по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Факультет.</returns>
		FacultyItem Get(int id);

		/// <summary>
		/// Обновляет данные по факультету.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		void Update(FacultyItem faculty);

		/// <summary>
		/// Создает новый факультет.
		/// </summary>
		/// <param name="faculty">Факультет.</param>
		/// <returns>Идентификатор созданного факультета.</returns>
		int Create(FacultyItem faculty);

		/// <summary>
		/// Удаляет задачу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех факультетов.
		/// </summary>
		/// <returns>Список факультетов.</returns>
		List<FacultyItem> GetList();
	}
}
