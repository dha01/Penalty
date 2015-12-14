using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Cathedra;

namespace IS.Model.Repository.Cathedra
{
	/// <summary>
	/// Интерфейс репозитория кафедр.
	/// </summary>
	public class CathedraRepository : ICathedraRepository
	{
		/// <summary>
		/// Получает кафедру по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Кафедра.</returns>
		public CathedraItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<CathedraItem>(@"
select
	d.cathedra Id,
	d.full_name FullName,
	d.short_name ShortName,
	d.faculty FacultyId
from Cathedra.cathedra d
where d.cathedra = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные у кафедры.
		/// </summary>
		/// <param name="cathedra">Кафедра.</param>
		public void Update(CathedraItem cathedra)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Cathedra.cathedra
set
	full_name = @FullName,
	short_name = @ShortName,
	faculty = @FacultyId 
where cathedra = @Id", cathedra);
			}
		}

		/// <summary>
		/// Создает новую кафедру.
		/// </summary>
		/// <param name="cathedra">Кафедра.</param>
		/// <returns>Идентификатор созданной кафедры.</returns>
		public int Create(CathedraItem cathedra)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Cathedra.cathedra
(
	full_name,
	short_name,
	faculty
)
values
(
	@FullName,
	@ShortName,
	@FacultyId
)

select scope_identity()", cathedra);
			}
		}

		/// <summary>
		/// Удаляет кафедру.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Cathedra.cathedra
where cathedra = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех кафедр.
		/// </summary>
		/// <returns>Список кафедр.</returns>
		public List<CathedraItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<CathedraItem>(@"
select
	d.cathedra Id,
	d.full_name FullName,
	d.short_name ShortName,
	d.faculty FacultyId
from Cathedra.cathedra d");
			}
		}
	}
}