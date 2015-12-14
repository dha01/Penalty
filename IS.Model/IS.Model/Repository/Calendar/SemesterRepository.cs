using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Calendar;

namespace IS.Model.Repository.Calendar
{
	/// <summary>
	/// Интерфейс репозитория семестра.
	/// </summary>
	public class SemesterRepository : ISemesterRepository
	{
		/// <summary>
		/// Получает задачу по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Задача.</returns>
		public SemesterItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<SemesterItem>(@"
select
	s.semester Id,
	s.from_date FromDate,
	s.trim_date TrimDate
from Calendar.semester s
where s.semester = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по семестру.
		/// </summary>
		/// <param name="semester">Семестр.</param>
		public void Update(SemesterItem semester)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Calendar.semester
set
	from_date = @FromDate,
	trim_date = @TrimDate
where semester = @Id", semester);
			}
		}

		/// <summary>
		/// Создает новый семестр.
		/// </summary>
		/// <param name="semester">Семестр.</param>
		/// <returns>Идентификатор созданного семестра.</returns>
		public int Create(SemesterItem semester)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Calendar.semester
(
	from_date,
	trim_date
)
values
(
	@FromDate,
	@TrimDate
)

select scope_identity()", semester);
			}
		}

		/// <summary>
		/// Удаляет семестр.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Calendar.semester
where semester = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех семестров.
		/// </summary>
		/// <returns>Список семестров.</returns>
		public List<SemesterItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<SemesterItem>(@"
select
	s.semester Id,
	s.from_date FromDate,
	s.trim_date TrimDate
from Calendar.semester s");
			}
		}
	}
}

