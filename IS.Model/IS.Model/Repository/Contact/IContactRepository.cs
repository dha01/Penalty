using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Access;
using IS.Model.Item.Contact;

namespace IS.Model.Repository.Contact
{
	/// <summary>
	/// Интерфейс репозитория контактов.
	/// </summary>
	public interface IContactRepository : IRepository<ContactItem>
	{
		/// <summary>
		/// Получает контакт по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Контакт.</returns>
		ContactItem Get(int id);

		/// <summary>
		/// Обновляет данные по контакту.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		void Update(ContactItem contact);

		/// <summary>
		/// Создает новый контакт.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		/// <returns>Идентификатор созданого контакта.</returns>
		int Create(ContactItem contact);

		/// <summary>
		/// Удаляет контакт.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		void Delete(int id);

		/// <summary>
		/// Получает список всех контактов.
		/// </summary>
		/// <returns>Список контактов.</returns>
		List<ContactItem> GetList();
	}
}
