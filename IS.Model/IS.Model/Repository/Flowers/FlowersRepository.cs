using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Flowers;

namespace IS.Model.Repository.Flowers
{
	/// <summary>
	/// Репозиторий цветов.
	/// </summary>
	public class FlowersRepository : IFlowersRepository
	{
		/// <summary>
		/// Получает цветок по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Цветок.</returns>
		public FlowersItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<FlowersItem>(@"
select
	d.flowers Id,
	d.name Name,
	d.family Family,
	d.color Color,
	d.thorns Thorns,
	d.longterm LongTerm,
	d.height Height
from Flowers.flowers d
where d.flowers = @id", new {id});
			}
		}

		/// <summary>
		/// Обновляет данные по цветку.
		/// </summary>
		/// <param name="flowers">Цветок.</param>
		public void Update(FlowersItem flowers)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Flowers.flowers
set
	name = @Name,
	family = @Family,
	color = @Color,
	thorns = @Thorns,
	longterm = @LongTerm,
	height = @Height
where flowers = @Id", flowers);
			}
		}

		/// <summary>
		/// Создает новый цветок.
		/// </summary>
		/// <param name="flowers">Цветок.</param>
		/// <returns>Идентификатор созданного цветка.</returns>
		public int Create(FlowersItem flowers)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Flowers.flowers
(
	name,
	family,
	color,
	thorns,
	longterm,
	height
)
values
(
	@Name,
	@Family,
	@Color,
	@Thorns,
	@LongTerm,
	@Height
)
select scope_identity()", flowers);
			}
		}

		/// <summary>
		/// Удаляет цветок.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Flowers.flowers
where flowers = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех цветов.
		/// </summary>
		/// <returns>Список цветов.</returns>
		public List<FlowersItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<FlowersItem>(@"
select
	d.flowers Id,
	d.name Name,
	d.family Family,
	d.color Color,
	d.thorns Thorns,
	d.longterm LongTerm,
	d.height Height
from Flowers.flowers d");
			}
		}
	}
}
