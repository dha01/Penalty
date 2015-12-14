using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Auditory;
using IS.Model.Helper;

namespace IS.Model.Repository.Auditory
{
	/// <summary>
	/// Класс репозитория аудиторий.
	/// </summary>
	public class AuditoryRepository : IAuditoryRepository
	{
		/// <summary>
		/// Получает аудиторию по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Аудитория.</returns>
		public AuditoryItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<AuditoryItem>(@"
select
	a.auditory Id,
	a.number Number,
	a.full_name FullName,
	a.memo Memo,
	a.level Level,
	a.capacity Capacity
from Auditory.auditory a
where a.auditory = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по аудитории.
		/// </summary>
		/// <param name="auditory">Аудитория.</param>
		public void Update(AuditoryItem auditory)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Auditory.auditory
set
	number = @Number,
	full_name = @FullName,
	memo = @Memo,
	level = @Level,
	capacity = @Capacity
where auditory = @Id", auditory);
			}
		}

		/// <summary>
		/// Создает новую аудиторию.
		/// </summary>
		/// <param name="auditory">Аудитория.</param>
		/// <returns>Идентификатор созданной аудитории.</returns>
		public int Create(AuditoryItem auditory)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Auditory.auditory
(
	number,
	full_name,
	memo,
	level,
	capacity
)
values
(
	@Number,
	@FullName,
	@Memo,
	@Level,
	@Capacity
)

select scope_identity()", auditory);
			}
		}

		/// <summary>
		/// Удаляет аудиторию.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Auditory.auditory
where auditory = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех аудиторий.
		/// </summary>
		/// <returns>Список аудиторий.</returns>
		public List<AuditoryItem> GetList()
		{
			return null;
		}
	}
}
