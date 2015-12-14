using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Housing;

namespace IS.Model.Repository.Housing
{
	/// <summary>
	/// Репозиторий корпусов.
	/// </summary>
	public class HousingRepository : IHousingRepository
	{
		/// <summary>
		/// Получает корпуса по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Корпус.</returns>
		public HousingItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<HousingItem>(@"
select
	d.housing Id,
	d.number Number,
	d.name Name,
	d.level Level,
	d.memo Memo
from Auditory.housing d
where d.housing = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по корпусу.
		/// </summary>
		/// <param name="housing">Корпус.</param>
		public void Update(HousingItem housing)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Auditory.housing
set
	number = @Number,
	name = @Name,
	level = @Level,
	memo = @Memo
where housing = @Id", housing);
			}
		}

		/// <summary>
		/// Создает новый корпус.
		/// </summary>
		/// <param name="housing">Корпус.</param>
		/// <returns>Идентификатор созданного корпуса.</returns>
		public int Create(HousingItem housing)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Auditory.housing
(
	number,
	name,
	level,
	memo
)
values
(
	@Number,
	@Name,
	@Level,
	@Memo
)

select scope_identity()", housing);
			}
		}

		/// <summary>
		/// Удаляет корпус.
		/// </summary>
		/// <param name="id">Корпус.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Auditory.housing
where housing = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех корпусов.
		/// </summary>
		/// <returns>Список корпусов.</returns>
		public List<HousingItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<HousingItem>(@"
select
	d.housing Id,
	d.number Number,
	d.name Name,
	d.level Level,
	d.memo Memo
from Auditory.housing d");
			}
		}
	}
}
