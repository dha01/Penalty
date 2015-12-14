using System.Collections.Generic;
using IS.Model.Item.Access;
using IS.Model.Repository;

namespace IS.Model.Repository.Access
{
	public interface IRoleRepository : IRepository<RoleItem>
	{
		RoleItem Get(int id);

		void Update(RoleItem item);

		int Create(RoleItem item);

		void Delete(int id);

		List<RoleItem> GetList();

		List<RoleItem> GetListByUser(UserItem user);

		RoleItem GetByCode(string code);
	}
}