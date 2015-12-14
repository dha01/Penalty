using System;
using System.Collections.Generic;
using System.Linq;
using IS.Model.Item.Person;
using IS.Model.Repository.Person;

namespace IS.Model.Service
{
	/// <summary>
	/// Сервис для работы с людьми.
	/// </summary>
	public class PersonService
	{
		#region Fields

		/// <summary>
		/// Репозиторий людей.
		/// </summary>
		private IPersonRepository _personRepository;

		#endregion

		#region Constructors

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		public PersonService()
		{
			_personRepository = new PersonRepository();
		}

		/// <summary>
		/// Конструктор класс.
		/// </summary>
		/// <param name="person_repository">Интерфейс репозитория людей.</param>
		public PersonService(IPersonRepository person_repository)
		{
			_personRepository = person_repository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Получает человека по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Человек.</returns>
		public PersonItem GetById(int id)
		{
			return _personRepository.Get(id);
		}

		/// <summary>
		/// Создает человека.
		/// </summary>
		/// <param name="person">Человек.</param>
		/// <returns>Идентификаторо созданного человека.</returns>
		public int Create(PersonItem person)
		{
			if (string.IsNullOrEmpty(person.FirstName))
			{
				throw new Exception("Поле 'FirstName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(person.FatherName))
			{
				throw new Exception("Поле 'FatherName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(person.LastName))
			{
				throw new Exception("Поле 'LastName' не должно быть пустым.");
			}

			return _personRepository.Create(person);
		}

		/// <summary>
		/// Измененяет данные о человеке.
		/// </summary>
		/// <param name="person">Человек.</param>
		public void Update(PersonItem person)
		{
			
			if (string.IsNullOrEmpty(person.FirstName))
			{
				throw new Exception("Поле 'FirstName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(person.FatherName))
			{
				throw new Exception("Поле 'FatherName' не должно быть пустым.");
			}

			if (string.IsNullOrEmpty(person.LastName))
			{
				throw new Exception("Поле 'LastName' не должно быть пустым.");
			}

			if (GetById(person.Id) == null)
			{
				throw new Exception("Человек не найден.");
			}

			_personRepository.Update(person);
		}

		/// <summary>
		/// Удаляет человека.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public void Delete(int id)
		{
			_personRepository.Delete(id);
		}

		/// <summary>
		/// Получает список людей.
		/// </summary>
		public List<PersonItem> GetList()
		{
			return _personRepository.GetList();
		}

		#endregion
	}
}
