using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Model.Item.Contact;
using IS.Model.Repository.Contact;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с контактами.
	/// </summary>
	public class ContactService
	{
		#region Fields

		/// <summary>
		/// Репозиторий контактов.
		/// </summary>
		private IContactRepository _contactRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public ContactService()
		{
			_contactRepository = new ContactRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="contact_repository">Интерфейс репозитория задач.</param>
		public ContactService(IContactRepository contact_repository)
		{
			_contactRepository = contact_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает контакт по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Контакт.</returns>
		public ContactItem GetById(int id)
		{
			return _contactRepository.Get(id);
		}

		/// <summary>
		/// Создает контакт.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		/// <returns>Идентификаторо созданного контакта.</returns>
		public int Create(ContactItem contact)
		{
			if (string.IsNullOrWhiteSpace(contact.Value))
			{
				throw new Exception("Поле 'Value' не должно быть пустым.");
			}
			return _contactRepository.Create(contact);
		}

		/// <summary>
		/// Измененяет данные о контакте.
		/// </summary>
		/// <param name="contact">Контакт.</param>
		public void Update(ContactItem contact)
		{
			if (string.IsNullOrWhiteSpace(contact.Value))
			{
				throw new Exception("Поле 'Value' не должно быть пустым.");
			}

			if (GetById(contact.Id) == null)
			{
				throw new Exception("Контакт не найден.");
			}

			_contactRepository.Update(contact);
		}

		/// <summary>
		/// Удаляет контакт.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_contactRepository.Delete(id);
		}

		/// <summary>
		/// Получает список контактов.
		/// </summary>
		public List<ContactItem> GetList()
		{
			return _contactRepository.GetList();
		}

		#endregion
	}
}
