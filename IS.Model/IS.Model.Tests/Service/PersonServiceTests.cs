using System;
using System.Collections.Generic;
using IS.Model.Item.Person;
using IS.Model.Repository.Person;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса людей.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class PersonServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис людей.
		/// </summary>
		private PersonService _personService;

		/// <summary>
		/// Репозиторий людей.
		/// </summary>
		private IPersonRepository _personRepository;

		/// <summary>
		/// Тестовый человек.
		/// </summary>
		private PersonItem _person;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_personRepository = Mock.Of<IPersonRepository>();
			_personService = new PersonService(_personRepository);

			_person = new PersonItem()
			{
				FirstName = "Василий",
				FatherName = "Петрович",
				LastName = "Иванов",
				Birthday = DateTime.Now.Date
			};
		}

		#endregion

		#region PersonService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void PersonService_Void_Success()
		{
			var s = new PersonService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает человека.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<PersonItem>() { _person };

			Mock.Get(_personRepository).Setup(x => x.Create(_person)).Returns(_person.Id);
			Mock.Get(_personRepository).Setup(x => x.GetList()).Returns(list);

			var result = _personService.Create(_person);
			Assert.AreEqual(result, _person.Id);
		}

		/// <summary>
		/// Создает человека с пустым именем.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FirstName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyFirstName_ReturnException()
		{
			_person.FirstName = null;
			_personService.Create(_person);
		}

		/// <summary>
		/// Создает человека с пустой фамилией.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'LastName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyLastName_ReturnException()
		{
			_person.LastName = null;
			_personService.Create(_person);
		}

		/// <summary>
		/// Создает человека с пустой отчество.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FatherName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyFatherName_ReturnException()
		{
			_person.FatherName = null;
			_personService.Create(_person);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет идентификатор на пустой.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Человек не найден.")]
		[Test]
		public void Update_PersonNotExists_ReturnException()
		{
			Mock.Get(_personRepository).Setup(x => x.Get(_person.Id)).Returns((PersonItem)null);
			_personService.Update(_person);
		}

		/// <summary>
		/// Изменяет данные о человеке.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_personRepository).Setup(x => x.Get(_person.Id)).Returns(_person);
			_personService.Update(_person);
		}

		/// <summary>
		/// Изменяет имя на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FirstName' не должно быть пустым.")]
		[Test]
		public void Update_EmptyFirstName_ReturnException()
		{
			_person.FirstName = null;
			_personService.Update(_person);
		}

		/// <summary>
		/// Изменяет фамилию на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'LastName' не должно быть пустым.")]
		[Test]
		public void Update_EmptyLastName_ReturnException()
		{
			_person.LastName = null;
			_personService.Update(_person);
		}

		/// <summary>
		/// Изменяет отчества на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FatherName' не должно быть пустым.")]
		[Test]
		public void Update_EmptyFatherName_ReturnException()
		{
			_person.FatherName = null;
			_personService.Update(_person);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет человека.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_personService.Delete(_person.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список людей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnPersonList()
		{
			var list = new List<PersonItem> { _person };

			Mock.Get(_personRepository).Setup(x => x.GetList()).Returns(list);
			var result = _personService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
