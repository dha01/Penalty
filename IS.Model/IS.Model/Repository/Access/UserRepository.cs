using System.Collections.Generic;
using IS.Model.Helper;
using IS.Model.Item.Access;

namespace IS.Model.Repository.Access
{
	public class UserRepository : IUserRepository
	{
		public UserItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<UserItem>(@"
select
	u.[user] Id,
	u.login Login,
	u.password Password
from Access.[user] u
where u.[user] = @id", new { id });
			}
		}

		public void Update(UserItem user)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Access.[user]
set
	login = @Login,
	password = @Password
where [user] = @Id", user);
			}
		}

		public int Create(UserItem user)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Access.[user] (login, password)
values (@Login, @Password)

select SCOPE_IDENTITY()", user);
			}
		}

		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Access.user
where [user] = @Id");
			}
		}

		public UserItem GetUserByLogin(string login)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<UserItem>(@"
select
	u.[user] Id,
	u.login Login,
	u.password Password
from Access.[user] u
where u.login = @login", new{ login });
			}
		}

		public List<UserItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<UserItem>(@"
select
	u.[user] Id,
	u.login Login,
	u.password Password
from Access.[user] u");
			}
		}
	}
}