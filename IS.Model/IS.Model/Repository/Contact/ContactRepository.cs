using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Helper;
using IS.Model.Item.Contact;

namespace IS.Model.Repository.Contact
{
	/// <summary>
	/// Интерфейс репозитория контактов.
	/// </summary>
	public class ContactRepository : IContactRepository
	{
		/// <summary>
		/// Получает контакт по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Контакт.</returns>
		public ContactItem Get(int id)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMapping<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type
where c.contact = @id", new { id });
			}
		}

		/// <summary>
		/// Обновляет данные по контакту.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		public void Update(ContactItem contact)
		{
			using (var sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
update Contact.contact
set
	contact_type = (select top 1 t.contact_type from Contact.contact_type t where t.code = @Type),
	value = @Value
where contact = @Id", contact);
			}
		}

		/// <summary>
		/// Создает новый контакт.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		/// <returns>Идентификатор созданного контакта.</returns>
		public int Create(ContactItem contact)
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecScalar<int>(@"
insert into Contact.contact
(
	contact_type,
	value
)
values
(
	(select top 1 t.contact_type from Contact.contact_type t where t.code = @Type),
	@Value
)

select scope_identity()", contact);
			}
		}

		/// <summary>
		/// Удаляет контакт.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			using (SqlHelper sqlh = new SqlHelper())
			{
				sqlh.ExecNoQuery(@"
delete from Contact.contact
where contact = @id", new { id });
			}
		}

		/// <summary>
		/// Получает список всех контактов.
		/// </summary>
		/// <returns>Список контактов.</returns>
		public List<ContactItem> GetList()
		{
			using (var sqlh = new SqlHelper())
			{
				return sqlh.ExecMappingList<ContactItem>(@"
select
	c.contact Id,
	t.code Type,
	c.value Value
from Contact.contact c
	join Contact.contact_type t on t.contact_type = c.contact_type");
			}
		}
	}
}
