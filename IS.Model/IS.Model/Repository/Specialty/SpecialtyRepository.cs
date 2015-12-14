using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Specialty;

namespace IS.Model.Repository.Specialty
{
	/// <summary>
	/// Интерфейс репозитория специальностей.
	/// </summary>
	public class SpecialtyRepository : ISpecialtyRepository
	{
		/// <summary>
		/// Получает специальность по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Специальность.</returns>
		public SpecialtyItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<SpecialtyItem>(@"
select
	s.specialty Id,
	s.full_name FullName,
	s.short_name ShortName,
	s.code Code
from Specialty.specialty s
where s.specialty = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по специальности.
		/// </summary>
		/// <param name="specialty">Специальность.</param>
		public void Update(SpecialtyItem specialty)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Specialty.specialty
set
	full_name = @FullName,
	short_name = @ShortName,
	code = @Code,
	cathedra = @CathedraId
where specialty = @Id", specialty);
			}
		}

		/// <summary>
		/// Создает новую специальность.
		/// </summary>
		/// <param name="specialty">Специальность.</param>
		/// <returns>Идентификатор созданной специальности.</returns>
		public int Create(SpecialtyItem specialty)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Specialty.specialty
(
	full_name,
	short_name,
	code,
	cathedra
)
values
(
	@FullName,
	@ShortName,
	@Code,
	@CathedraId
)
select scope_identity()", specialty);
			}
		}

		/// <summary>
		/// Удаляет специальность.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecMapping<SpecialtyItem>(@"
delete from Specialty.specialty 
where specialty = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех специальностей.
		/// </summary>
		/// <returns>Список специальностей.</returns>
		public List<SpecialtyItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<SpecialtyItem>(@"
select
	s.specialty Id,
	s.full_name FullName,
	s.short_name ShortName,
	s.code Code
from Specialty.specialty s");
			}
		}
	}
}
