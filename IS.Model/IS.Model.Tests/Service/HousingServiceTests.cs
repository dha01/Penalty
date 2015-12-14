using System;
using System.Collections.Generic;
using IS.Model.Item.Discipline;
using IS.Model.Item.Housing;
using IS.Model.Repository.Discipline;
using IS.Model.Repository.Housing;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса дисциплин.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class HousingServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис корпусов.
		/// </summary>
		private HousingService _housingService;

		/// <summary>
		/// Репозиторий корпусов.
		/// </summary>
		private IHousingRepository _housingRepository;

		/// <summary>
		/// Тестовый корпус.
		/// </summary>
		private HousingItem _housing;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_housingRepository = Mock.Of<IHousingRepository>();
			_housingService = new HousingService(_housingRepository);

			_housing = new HousingItem()
			{
				Id = 1,
				Name = "test",
				Memo = "Описание"
			};
		}

		#endregion

		#region HousingService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void HousingService_Void_Success()
		{
			var s = new HousingService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает корпус.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<HousingItem>() { _housing };

			Mock.Get(_housingRepository).Setup(x => x.Create(_housing)).Returns(_housing.Id);
			Mock.Get(_housingRepository).Setup(x => x.GetList()).Returns(list);

			var result = _housingService.Create(_housing);
			Assert.AreEqual(result, _housing.Id);
		}

		/// <summary>
		/// Создает корпус с пустым полем "Name".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Create_EmptyName_ReturnException()
		{
			_housing.Name = null;
			_housingService.Create(_housing);
		}

		/// <summary>
		/// Создает корпус с пустым полем "Memo".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Memo' не должно быть пустым.")]
		[Test]
		public void Create_EmptyMemo_ReturnException()
		{
			_housing.Memo = null;
			_housingService.Create(_housing);
		}


		#endregion

		#region Update


		/// <summary>
		/// Изменяет данные о корпусе.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_housingRepository).Setup(x => x.Get(_housing.Id)).Returns(_housing);
			_housingService.Update(_housing);
		}

		/// <summary>
		/// Изменяет поле "Name" на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Update_EmptyName_ReturnException()
		{
			_housing.Name = null;
			_housingService.Update(_housing);
		}

		/// <summary>
		/// Изменяет поле "Memo" на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Memo' не должно быть пустым.")]
		[Test]
		public void Update_EmptyMemo_ReturnException()
		{
			_housing.Memo = null;
			_housingService.Update(_housing);
		}

		/// <summary>
		/// Изменяет описание на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Корпус не найден.")]
		[Test]
		public void Update_HousingNotExists_ReturnException()
		{
			Mock.Get(_housingRepository).Setup(x => x.Get(_housing.Id)).Returns((HousingItem)null);
			_housingService.Update(_housing);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет дисциплину.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_housingService.Delete(_housing.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список дисциплин.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnTaskList()
		{
			var list = new List<HousingItem> { _housing };

			Mock.Get(_housingRepository).Setup(x => x.GetList()).Returns(list);
			var result = _housingService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
