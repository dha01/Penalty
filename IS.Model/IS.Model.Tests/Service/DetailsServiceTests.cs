using System;
using System.Collections.Generic;
using IS.Model.Item.Details;
using IS.Model.Repository.Details;
using IS.Model.Service;
using Moq;
using NUnit.Framework;

namespace IS.Model.Tests.Service
{
	/// <summary>
	/// Тесты для сервиса деталей.
	/// </summary>
	[Category("Unit")]
	[TestFixture]
	public class DetailsServiceTests
	{
		#region Fields

		/// <summary>
		/// Сервис деталей.
		/// </summary>
		private DetailsService _detailsService;

		/// <summary>
		/// Репозиторий деталей.
		/// </summary>
		private IDetailsRepository _detailsRepository;

		/// <summary>
		/// Тестовая деталь.
		/// </summary>
		private DetailsItem _details;
		private string Name;
		private DateTime ReleaseDate;
		private int Weight;
		private int Height;
		private int Lenght;
		private int Mass;
		private DetailsMaterial Material;
		private string Mem;

		#endregion

		#region SetUp

		/// <summary>
		/// Выполняется перед каждым тестом.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_detailsRepository = Mock.Of<IDetailsRepository>();
			_detailsService = new DetailsService(_detailsRepository);

			_details = new DetailsItem()
			{
				Name = "Test1",
				ReleaseDate = DateTime.Now.Date,
				Weight = 100,
				Height = 100,
				Lenght = 100,
				Mass = 100,
				Material = DetailsMaterial.Wood,
				Mem = "Дерево",
			};
		}

		#endregion

		#region DetailsService

		/// <summary>
		/// Конструктор без параметров.
		/// </summary>
		[Test]
		public void DetailsService_Void_Success()
		{
			var s = new DetailsService();
		}

		#endregion

		#region Create

		/// <summary>
		/// Создает деталь.
		/// </summary>
		[Test]
		public void Create_Void_ReturnId()
		{
			var list = new List<DetailsItem>() { _details };

			Mock.Get(_detailsRepository).Setup(x => x.Create(_details)).Returns(_details.Id);
			Mock.Get(_detailsRepository).Setup(x => x.GetList()).Returns(list);

			var result = _detailsService.Create(_details);
			Assert.AreEqual(result, _details.Id);
		}

		/// <summary>
		/// Создает деталь с пустым полем "Mem".
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Create_EmptyMem_ReturnException()
		{
			_details.Mem = null;
			_detailsService.Create(_details);
		}

		#endregion

		#region Update

		/// <summary>
		/// Изменяет данные детали.
		/// </summary>
		[Test]
		public void Update_Void_Success()
		{
			Mock.Get(_detailsRepository).Setup(x => x.Get(_details.Id)).Returns(_details);
			_detailsService.Update(_details);
		}

		/// <summary>
		/// Изменяет поле "Mem" на пустое.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Поле 'Mem' не должно быть пустым.")]
		[Test]
		public void Update_EmptyMem_ReturnException()
		{
			_details.Mem = null;
			_detailsService.Update(_details);
		}

		/// <summary>
		/// Изменяет не существующую деталь.
		/// </summary>
		[ExpectedException(ExpectedMessage = "Деталь не найден.")]
		[Test]
		public void Update_DetailsNotExists_ReturnException()
		{
			Mock.Get(_detailsRepository).Setup(x => x.Get(_details.Id)).Returns((DetailsItem)null);
			_detailsService.Update(_details);
		}

		#endregion

		#region Delete

		/// <summary>
		/// Удаляет деталь.
		/// </summary>
		[Test]
		public void Delete_Void_Success()
		{
			_detailsService.Delete(_details.Id);
		}

		#endregion

		#region GetList

		/// <summary>
		/// Получает список деталей.
		/// </summary>
		[Test]
		public void GetList_Void_ReturnDetailsList()
		{
			var list = new List<DetailsItem> { _details };

			Mock.Get(_detailsRepository).Setup(x => x.GetList()).Returns(list);
			var result = _detailsService.GetList();

			Assert.AreEqual(result.Count, list.Count);
		}

		#endregion

	}
}