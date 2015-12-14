using System;
using System.Collections.Generic;
using IS.Model.Item.Faculty;
using IS.Model.Repository.Faculty;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса факультетов.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class FacultyServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис факультетов.
		/// </summary>
		private FacultyService _facultyService;

		/// <summary>
		/// Репозиторий факультетов.
		/// </summary>
		private IFacultyRepository _facultyRepository;

		/// <summary>
		/// Тестовый факультет.
		/// </summary>
		private FacultyItem _faculty;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_facultyRepository = Mock.Of<IFacultyRepository>();
			_facultyService = new FacultyService(_facultyRepository);

			_faculty = new FacultyItem()
			{
				FullName = "Экономический",
				ShortName = "Э"
			};
		}

		#endregion

		#region FacultyService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void FacultyService_Void_Success()
		{
			var s = new FacultyService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает факультет.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<FacultyItem>() { _faculty };

			Mock.Get(_facultyRepository).Setup(x => x.Create(_faculty)).Returns(_faculty.Id);
			Mock.Get(_facultyRepository).Setup(x => x.GetList()).Returns(list);

			var result = _facultyService.Create(_faculty);
			Assert.AreEqual(result, _faculty.Id);
		}

		/// <summary>
		/// Создает факультет с пустым полным именем.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FullName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyFulltName_ReturnException()
		{
			_faculty.FullName = null;
			_facultyService.Create(_faculty);
		}

		/// <summary>
		/// Создает факультет с пустым сокращенным именем.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'ShortName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyShortName_ReturnException()
		{
			_faculty.ShortName = null;
			_facultyService.Create(_faculty);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет идентификатор на пустой.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Факультет не найден.")]
		[Test]
		public void Update_FacultyNotExists_ReturnException()
		{
			Mock.Get(_facultyRepository).Setup(x => x.Get(_faculty.Id)).Returns((FacultyItem)null);
			_facultyService.Update(_faculty);
		}

		/// <summary>
		/// Изменяет данные о факультете.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_facultyRepository).Setup(x => x.Get(_faculty.Id)).Returns(_faculty);
			_facultyService.Update(_faculty);
		}

		/// <summary>
		/// Изменяет полное имя на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FullName' не должно быть пустым.")]
		[Test]
		public void Update_EmptyFullName_ReturnException()
		{
			_faculty.FullName = null;
			_facultyService.Update(_faculty);
		}

		/// <summary>
		/// Изменяет сокращенное имя на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'ShortName' не должно быть пустым.")]
		[Test]
		public void Update_EmptyShortName_ReturnException()
		{
			_faculty.ShortName = null;
			_facultyService.Update(_faculty);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет факультет.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_facultyService.Delete(_faculty.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список факультетов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnFacultyList()
		{
			var list = new List<FacultyItem> { _faculty };

			Mock.Get(_facultyRepository).Setup(x => x.GetList()).Returns(list);
			var result = _facultyService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
