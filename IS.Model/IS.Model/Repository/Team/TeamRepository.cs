using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Team;

namespace IS.Model.Repository.Team
{
	/// <summary>
	/// Интерфейс репозитория группы.
	/// </summary>
	public class TeamRepository : ITeamRepository
	{
		/// <summary>
		/// Получает группу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Группу.</returns>
		public TeamItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<TeamItem>(@"
select
	t.team Id,
	t.name Name,
	t.create_date CreateDate,
	t.specialty_detail SpecialtyDetailId
from Team.team t
where t.team = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по группе.
		/// </summary>
		/// <param name="team">Группу.</param>
		public void Update(TeamItem team)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Team.Team
set
	name = @Name,
	create_date = @CreateDate,
	specialty_detail = @SpecialtyDetailId
where Team = @Id", team);
			}
		}

		/// <summary>
		/// Создает новую группу.
		/// </summary>
		/// <param name="team">Группу.</param>
		/// <returns>Идентификатор созданной группу.</returns>
		public int Create(TeamItem team)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Team.Team
(
	name,
	create_date,
	specialty_detail
)
values
(
	@Name,
	@CreateDate,
	@SpecialtyDetailId
)

select scope_identity()", team);
			}
		}

		/// <summary>
		/// Удаляет группу.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecMapping<TeamItem>(@"
delete from Team.team
where team = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех группу.
		/// </summary>
		/// <returns>Список группу.</returns>
		public List<TeamItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<TeamItem>(@"
select
	t.team Id,
	t.name Name,
	t.create_date CreateDate,
	t.specialty_detail SpecialtyDetailId
from Team.team t
");
			}
		}
	}
}