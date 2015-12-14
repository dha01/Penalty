using System;
using System.Collections.Generic;
using IS.Model.Item.Cathedra;
using IS.Model.Repository.Cathedra;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса кафедр.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class CathedraServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис кафедр.
		/// </summary>
		private CathedraService _cathedraService;

		/// <summary>
		/// Репозиторий кафедр.
		/// </summary>
		private ICathedraRepository _cathedraRepository;

		/// <summary>
		/// Тестовая кафедра.
		/// </summary>
		private CathedraItem _cathedra;
		private string FullName;
		private string ShortName;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_cathedraRepository = Mock.Of<ICathedraRepository>();
			_cathedraService = new CathedraService(_cathedraRepository);

			_cathedra = new CathedraItem()
			{
				FullName = "Информациионных систем и технологий",
				ShortName = "ИСиТ",
				FacultyId = 1
			};
		}

		#endregion

		#region CathedraService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void CathedraService_Void_Success()
		{
			var s = new CathedraService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает кафедру.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<CathedraItem>() { _cathedra };

			Mock.Get(_cathedraRepository).Setup(x => x.Create(_cathedra)).Returns(_cathedra.Id);
			Mock.Get(_cathedraRepository).Setup(x => x.GetList()).Returns(list);

			var result = _cathedraService.Create(_cathedra);
			Assert.AreEqual(result, _cathedra.Id);
		}

		/// <summary>
		/// Создает кафедру с пустым полем "FullName".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FullName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyFullName_ReturnException()
		{
			_cathedra.FullName = null;
			_cathedraService.Create(_cathedra);
		}

		/// <summary>
		/// Создает кафедру с пустым полем "ShortName".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'ShortName' не должно быть пустым.")]
		[Test]
		public void Create_EmptyShortName_ReturnException()
		{
			_cathedra.ShortName = null;
			_cathedraService.Create(_cathedra);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные о кафедре.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_cathedraRepository).Setup(x => x.Get(_cathedra.Id)).Returns(_cathedra);
			_cathedraService.Update(_cathedra);
		}

		/// <summary>
		/// Изменяет поле "FullName" на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'FullName' не должно быть пустым.")]
		[Test]
		public void Update_EmptyFullName_ReturnException()
		{
			_cathedra.FullName = null;
			_cathedraService.Update(_cathedra);
		}

		/// <summary>
		/// Изменяет поле "ShortName" на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'ShortName' не должно быть пустым.")]
		[Test]
		public void Update_EmptyShortName_ReturnException()
		{
			_cathedra.ShortName = null;
			_cathedraService.Update(_cathedra);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Кафедра не найдена.")]
		[Test]
		public void Update_DisciplineNotExists_ReturnException()
		{
			Mock.Get(_cathedraRepository).Setup(x => x.Get(_cathedra.Id)).Returns((CathedraItem)null);
			_cathedraService.Update(_cathedra);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет кафедру.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_cathedraService.Delete(_cathedra.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список кафедр.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnTaskList()
		{
			var list = new List<CathedraItem> { _cathedra };

			Mock.Get(_cathedraRepository).Setup(x => x.GetList()).Returns(list);
			var result = _cathedraService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion

	}
}
