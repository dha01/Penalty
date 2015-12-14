using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Model.Item.Contact;
using IS.Model.Repository.Contact;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса контактов.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class ContactServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис контактов.
		/// </summary>
		private ContactService _contactService;

		/// <summary>
		/// Репозиторий контактов.
		/// </summary>
		private IContactRepository _contactRepository;

		/// <summary>
		/// Тестовый контакт.
		/// </summary>
		private ContactItem _contact;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_contactRepository = Mock.Of<IContactRepository>();
			_contactService = new ContactService(_contactRepository);

			_contact = new ContactItem()
			{
				Id = 1,
				Type = ContactType.MobilePhone,
				Value = "8-999-999-99-99"
			};
		}

		#endregion

		#region ContactService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void ContactService_Void_Success()
		{
			var s = new ContactService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает контакт.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<ContactItem>() { _contact };

			Mock.Get(_contactRepository).Setup(x => x.Create(_contact)).Returns(_contact.Id);
			Mock.Get(_contactRepository).Setup(x => x.GetList()).Returns(list);

			var result = _contactService.Create(_contact);
			Assert.AreEqual(result, _contact.Id);
		}

		/// <summary>
		/// Создает контакт с пустым значением.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Value' не должно быть пустым.")]
		[Test]
		public void Create_EmptyValue_ReturnException()
		{
			_contact.Value = null;
			_contactService.Create(_contact);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о контакте.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_contactRepository).Setup(x => x.Get(_contact.Id)).Returns(_contact);
			_contactService.Update(_contact);
		}

		/// <summary>
		/// Изменяет значение на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Value' не должно быть пустым.")]
		[Test]
		public void Update_EmptyValue_ReturnException()
		{
			_contact.Value = null;
			_contactService.Update(_contact);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет контакт.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_contactService.Delete(_contact.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список контактов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnContactList()
		{
			var list = new List<ContactItem> { _contact };

			Mock.Get(_contactRepository).Setup(x => x.GetList()).Returns(list);
			var result = _contactService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
