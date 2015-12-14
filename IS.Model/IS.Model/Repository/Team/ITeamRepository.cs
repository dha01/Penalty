using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Item.Team;

namespace IS.Model.Repository.Team
{
	/// <summary>
	/// Интерфейс репозитория группы.
	/// </summary>
	public interface ITeamRepository : IRepository<TeamItem>
	{
		/// <summary>
		/// Получает группу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Группу.</returns>
		TeamItem Get(int id);

		/// <summary>
		/// Обновляет данные по группе.
		/// </summary>
		/// <param name="Team">Группу.</param>
		void Update(TeamItem Team);

		/// <summary>
		/// Создает новую группу.
		/// </summary>
		/// <param name="Team">Группу.</param>
		/// <returns>Идентификатор созданной группу.</returns>
		int Create(TeamItem Team);

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех группу.
		/// </summary>
		/// <returns>Список группу.</returns>
		List<TeamItem> GetList();
	}
}