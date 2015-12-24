using System;
using System.Collections.Generic;
using IS.Model.Item.Flowers;
using IS.Model.Repository.Flowers;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса цветов.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class FlowersServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис цветов.
		/// </summary>
		private FlowersService _flowersService;

		/// <summary>
		/// Репозиторий цветов.
		/// </summary>
		private IFlowersRepository _flowersRepository;

		/// <summary>
		/// Тестовый цветок.
		/// </summary>
		private FlowersItem _flowers;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_flowersRepository = Mock.Of<IFlowersRepository>();
			_flowersService = new FlowersService(_flowersRepository);

			_flowers = new FlowersItem()
			{
				Name = "Роза",
				Family = FlowersFamily.Shipownikovie,
				Color = FlowersColor.Red,
				Thorns = "Да",
				LongTerm = "Да",
				Height = 90,
			};
		}

		#endregion

		#region FlowersService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void FlowersService_Void_Success()
		{
			var s = new FlowersService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает цветок.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<FlowersItem>() { _flowers };

			Mock.Get(_flowersRepository).Setup(x => x.Create(_flowers)).Returns(_flowers.Id);
			Mock.Get(_flowersRepository).Setup(x => x.GetList()).Returns(list);

			var result = _flowersService.Create(_flowers);
			Assert.AreEqual(result, _flowers.Id);
		}

		/// <summary>
		/// Создает цветок с пустым полным именем.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Create_EmptyName_ReturnException()
		{
			_flowers.Name = null;
			_flowersService.Create(_flowers);
		}

		/// <summary>
		/// Изменяет название на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Name' не должно быть пустым.")]
		[Test]
		public void Update_EmptyName_ReturnException()
		{
			_flowers.Name = null;
			_flowersService.Update(_flowers);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет цветок.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_flowersService.Delete(_flowers.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список цветов.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnFlowersList()
		{
			var list = new List<FlowersItem> { _flowers };

			Mock.Get(_flowersRepository).Setup(x => x.GetList()).Returns(list);
			var result = _flowersService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion
	}
}
