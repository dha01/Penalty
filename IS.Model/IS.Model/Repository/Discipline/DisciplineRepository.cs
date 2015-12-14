using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Discipline;

namespace IS.Model.Repository.Discipline
{
	/// <summary>
	/// Репозиторий дисциплин.
	/// </summary>
	public class DisciplineRepository : IDisciplineRepository
	{
		/// <summary>
		/// Получает дисциплину по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Дисциплина.</returns>
		public DisciplineItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<DisciplineItem>(@"
select
	d.discipline Id,
	d.short_name ShortName,
	d.full_name FullName,
	d.mem Mem
from Discipline.discipline d
where d.discipline = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по дисциплине.
		/// </summary>
		/// <param name="discipline">Дисциплина.</param>
		public void Update(DisciplineItem discipline)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Discipline.discipline
set
	short_name = @ShortName,
	mem = @Mem,
	full_name = @FullName
where discipline = @Id", discipline);
			}
		}

		/// <summary>
		/// Создает новую дисциплину.
		/// </summary>
		/// <param name="discipline">Дисциплина.</param>
		/// <returns>Идентификатор созданной дисциплины.</returns>
		public int Create(DisciplineItem discipline)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Discipline.discipline
(
	short_name,
	full_name,
	mem
)
values
(
	@ShortName,
	@FullName,
	@Mem
)

select scope_identity()", discipline);
			}
		}

		/// <summary>
		/// Удаляет дисциплину.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Discipline.discipline
where discipline = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех дисциплин.
		/// </summary>
		/// <returns>Список дисциплин.</returns>
		public List<DisciplineItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<DisciplineItem>(@"
select
	d.discipline Id,
	d.short_name ShortName,
	d.full_name FullName,
	d.mem Mem
from Discipline.discipline d");
			}
		}
	}
}
