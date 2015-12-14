using System.Collections.Generic;
using System.Data;
using IS.Model.Helper;
using IS.Model.Item.Access;

namespace IS.Model.Repository.Access
{
	/// <summary>
	/// Класс репозитория ролей.
	/// </summary>
	public class RoleRepository : IRoleRepository
	{
		/// <summary>
		/// Получает роль по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Роль.</returns>
		public RoleItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r
where r.role = @Id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по роли.
		/// </summary>
		/// <param name="role">Роль.</param>
		public void Update(RoleItem role)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Access.role
set
	code = @Code,
	mem = @Mem
where role = @Id", role);
			}
		}

		/// <summary>
		/// Создает новую роль.
		/// </summary>
		/// <param name="role">Роль.</param>
		/// <returns>Идентификатор созданной роли.</returns>
		public int Create(RoleItem role)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Access.role
(
	code,
	mem
)
values
(
	@Code,
	@Mem
)

select scope_identity()", role);
			}
		}

		/// <summary>
		/// Удаляет роль.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Access.role
where role = @Id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех ролей.
		/// </summary>
		/// <returns>Список ролей.</returns>
		public List<RoleItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r");
			}
		}

		/// <summary>
		/// Получает список ролей по пользователю.
		/// </summary>
		/// <param name="user">Пользователь.</param>
		/// <returns>Список ролей.</returns>
		public List<RoleItem> GetListByUser(UserItem user)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.[user] u
	join Access.user2role u2r on u2r.[user] = u.[user]
	join Access.role r on r.role = u2r.role
where u.[user] = @Id", user);
			}
		}

		/// <summary>
		/// Получает роль по коду.
		/// </summary>
		/// <param name="code">Код.</param>
		/// <returns>Список ролей.</returns>
		public RoleItem GetByCode(string code)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<RoleItem>(@"
select
	r.role Id,
	r.code Code,
	r.mem Mem
from Access.role r
where r.code = @Code", new { code });
			}
		}
	}
}