using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Repository;

namespace IS.Model.Repository.Access
{
	public interface IUserRepository : IRepository<UserItem>
	{
		UserItem Get(int id);

		void Update(UserItem role);

		int Create(UserItem role);

		void Delete(int id);

		UserItem GetUserByLogin(string login);

		List<UserItem> GetList();
	}
}